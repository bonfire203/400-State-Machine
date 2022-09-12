using UnityEngine;

public class CrowTravelState : CrowBaseState
{
    GameObject[] cropArray = new GameObject[] {};
    public float speed = 10f;
    int cropID = 1;

    public override void EnterState(CrowStateManager crow){
        cropArray = GameObject.FindGameObjectsWithTag("crop");
        cropID = Random.Range(0, cropArray.Length);
    }

    public override void UpdateState(CrowStateManager crow){
        crow.transform.position = Vector3.MoveTowards(crow.transform.position, cropArray[cropID].transform.position, speed * Time.deltaTime);
        //animation/ani state 
    }

    public override void OnCollisionEnter(CrowStateManager crow, Collision collision){
        if(collision.gameObject.tag == "crop"){
            crow.SwitchState(crow.EatingState);
        }
        
    }
}
