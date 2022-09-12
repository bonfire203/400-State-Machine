using UnityEngine;
using System.Collections.Generic;

public class CrowEatingState : CrowBaseState
{
    public override void EnterState(CrowStateManager crow){
        Debug.Log("Eating");
        crow.Invoke("EatCrop", 10f);//does not work
    }
    public override void UpdateState(CrowStateManager crow){
        //do coroutine or something
    }
    public override void OnCollisionEnter(CrowStateManager crow, Collision collision){
        
    }

    //does not work
    void EatCrop(){
        //do animation()
        Debug.Log("Eating");
    }
}
