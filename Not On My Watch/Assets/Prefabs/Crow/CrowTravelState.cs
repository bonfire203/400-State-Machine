using UnityEngine;

public class CrowTravelState : CrowBaseState
{
    public override void EnterState(CrowStateManager crow){
        Debug.Log("Hello :)");
    }
    public override void UpdateState(CrowStateManager crow){
        //Travel to a crop
        
        //find crop
        //move to crop
        //Debug.Log("Finding crop");
    }
    public override void OnCollisionEnter(CrowStateManager crow){
        
    }
}
