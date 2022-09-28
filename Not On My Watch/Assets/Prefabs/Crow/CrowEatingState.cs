using UnityEngine;
using System.Collections.Generic;

public class CrowEatingState : CrowBaseState
{
    CrowAnimations anim;
    public override void EnterState(CrowStateManager crow){
        //StartCoroutine(EatCrop(5f));
        crow.CountDown();
        anim.AttackCorn();
    }

    public override void UpdateState(CrowStateManager crow){
          
    }

    public override void OnCollisionEnter(CrowStateManager crow, Collision collision){
        
    }

    /*IEnumerator EatCrop(float i){
        //do animation()
        Debug.Log("Eating");
        yield return new WaitForSeconds(i);
        StartCoroutine(SpawnCrow());  
    }*/


}
