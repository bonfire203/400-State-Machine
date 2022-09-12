using UnityEngine;

public class CrowTravelState : CrowBaseState
{
    GameObject[] cropArray = new GameObject[] {};
    public float speed = 10f;
    int cropID = 1;

    public override void EnterState(CrowStateManager crow){
        cropArray = GameObject.FindGameObjectsWithTag("corn");
        cropID = Random.Range(0, cropArray.Length);
    }

    public override void UpdateState(CrowStateManager crow){
        crow.transform.position = Vector3.MoveTowards(crow.transform.position, cropArray[cropID].transform.position, speed * Time.deltaTime);
        //animation/ani state 
    }

    public override void OnCollisionEnter(CrowStateManager crow, Collision collision){
        if(collision.gameObject.tag == "corn"){
            crow.SwitchState(crow.EatingState);
        }
        if(collision.gameObject.tag == "fl_collision" || collision.gameObject.tag == "hm_collision" || collision.gameObject.tag == "ss_collision")
        {
            crow.SwitchState(crow.FleeingState);
        }
        
    }
}
