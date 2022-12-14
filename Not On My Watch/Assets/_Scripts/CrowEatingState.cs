using UnityEngine;
using System.Collections.Generic;
using Photon.Pun;

public class CrowEatingState : CrowBaseState
{
    private float timeRemaining = 8;
    private bool timerRunning = false;
    float duration = 3;
    //public CrowAnimations anim = new CrowAnimations();
    GameObject eatingCorn;

    public override void EnterState(CrowStateManager crow){

        timerRunning = true;
        crow.CrowAnim.AttackCorn(crow);
    }
    public override void UpdateState(CrowStateManager crow){
        //do coroutine or something
        if(eatingCorn != null)
        {
            if (timerRunning)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                }
                else
                {
                    //Flee rather than travel
                    crow.SwitchState(crow.FleeingState);
                    timeRemaining = 0;
                    timerRunning = false;
                    //MainManager.Instance.cornLost++;
                    crow.crowGO.GetComponent<PhotonView>().RequestOwnership();
                    crow.DestroyCorn(eatingCorn);
                    //Destroy(specificcorn)
                }
            }
        }
        else
        {
            crow.SwitchState(crow.TravelState);
        }
        
    }
    public override void OnTriggerEnter( Collider collision){
        CrowStateManager crow = gameObject.GetComponent<CrowStateManager>();

        if (collision.gameObject.tag == "fl_collision" || collision.gameObject.tag == "hm_collision")
        {
            Debug.Log("Flee now");
            crow.SwitchState(crow.FleeingState);
        }
        if (collision.gameObject.tag == "hm_collision")
        {
            duration = 3;
        }
        if (collision.gameObject.tag == "corn")
        {

            eatingCorn = collision.gameObject;
            //Destroy(collision.gameObject);
        }
    }

    //public void OnCollisionStay(CrowStateManager crow, Collision collision)
    //{
    //    Debug.Log("Made it to oncollision stay");
    //    if (collision.gameObject.tag == "corn")
    //    {
    //        eatingCorn = collision.gameObject;
    //        //Destroy(collision.gameObject);
    //    }
    //    if (collision.gameObject.tag == "hm_collision")
    //    {
    //        Debug.Log("Duration: " + duration);
    //        if (duration > 0)
    //        {
    //            duration -= Time.deltaTime;
    //        }
    //        else
    //        {
    //            crow.SwitchState(crow.FleeingState);
    //        }
    //    }
    //}
}
