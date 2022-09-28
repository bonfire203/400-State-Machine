using UnityEngine;
using System.Collections.Generic;

public class CrowEatingState : CrowBaseState
{
    private float timeRemaining = 5;
    private bool timerRunning = false;
    public CrowAnimations anim = new CrowAnimations();
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
                crow.SwitchState(crow.FleeingState);
                timeRemaining = 0;
                timerRunning = false;
            }
        }
    }
    public override void OnCollisionEnter(CrowStateManager crow, Collision collision){
        
    }
}
