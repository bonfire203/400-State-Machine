using UnityEngine;
using System.Collections.Generic;

public class CrowEatingState : CrowBaseState
{
    CrowAnimations anim;
    public override void EnterState(CrowStateManager crow){
        crow.Invoke("EatCrop", 10f);
        anim.AttackCorn();

    }
    public override void UpdateState(CrowStateManager crow){
        //do coroutine or something
    }
    public override void OnCollisionEnter(CrowStateManager crow, Collision collision){
        
    }

    //does not work
    public void EatCrop(){
        //do animation()
        Debug.Log("Eating");
    }
}
