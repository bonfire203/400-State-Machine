using UnityEngine;

public class CrowFleeingState : CrowBaseState
{
    public CrowAnimations anim = new CrowAnimations();
    public override void EnterState(CrowStateManager crow){
        anim.Fly(crow);
    }
    public override void UpdateState(CrowStateManager crow){
        
    }
    public override void OnCollisionEnter(CrowStateManager crow, Collision collision){
        
    }
}
