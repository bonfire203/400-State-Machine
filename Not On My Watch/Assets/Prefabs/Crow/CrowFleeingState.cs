using UnityEngine;
using System;

public class CrowFleeingState : CrowBaseState
{
    Vector3 targetVector = new Vector3(0f, 75f, 0f);
    public CrowAnimations anim = new CrowAnimations();
    public override void EnterState(CrowStateManager crow){
        anim.Fly(crow);
        crow.DestroyCrow();
    }
    public override void UpdateState(CrowStateManager crow){
        crow.transform.position = Vector3.MoveTowards(crow.transform.position, targetVector, 2f * Time.deltaTime);
    }
    public override void OnCollisionEnter(CrowStateManager crow, Collision collision){

    }
}
