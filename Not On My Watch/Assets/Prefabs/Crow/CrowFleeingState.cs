using UnityEngine;

public class CrowFleeingState : CrowBaseState
{
    CrowAnimations anim;
    public override void EnterState(CrowStateManager crow){
        anim.Fly();
    }
    public override void UpdateState(CrowStateManager crow){
        
    }
    public override void OnCollisionEnter(CrowStateManager crow, Collision collision){
        
    }
}
