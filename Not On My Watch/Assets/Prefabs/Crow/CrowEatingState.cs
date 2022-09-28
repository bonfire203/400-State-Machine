using UnityEngine;
using System.Collections.Generic;

public class CrowEatingState : CrowBaseState
{
    private float timeRemaining = 5;
    private bool timerRunning = false;
    float duration = 3;
    public CrowAnimations anim = new CrowAnimations();
    GameObject eatingCorn;

    public override void EnterState(CrowStateManager crow){
        timerRunning = true;
        anim.AttackCorn(crow);
    }
    public override void UpdateState(CrowStateManager crow){
        //do coroutine or something
        if (timerRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                //Flee rather than travel
                crow.SwitchState(crow.TravelState);
                timeRemaining = 0;
                timerRunning = false;
                MainManager.Instance.cornLost++;
                crow.DestroyCorn(eatingCorn);
                //Destroy(specificcorn)
            }
        }
    }
    public override void OnCollisionEnter(CrowStateManager crow, Collision collision){
        if (collision.gameObject.tag == "fl_collision" || collision.gameObject.tag == "hm_collision")
        {
            Debug.Log("Flee now");
            crow.SwitchState(crow.FleeingState);
        }
        if (collision.gameObject.tag == "hm_collision")
        {
            duration = 3;
        }
    }

    public void OnCollisionStay(CrowStateManager crow, Collision collision)
    {
        Debug.Log("Made it to oncollision stay");
        if (collision.gameObject.tag == "corn")
        {
            eatingCorn = collision.gameObject;
            //Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "hm_collision")
        {
            Debug.Log("Duration: " + duration);
            if (duration > 0)
            {
                duration -= Time.deltaTime;
            }
            else
            {
                crow.SwitchState(crow.FleeingState);
            }
        }
    }
}
