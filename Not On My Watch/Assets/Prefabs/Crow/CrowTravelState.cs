using UnityEngine;

public class CrowTravelState : CrowBaseState
{
    CrowAnimations anim;
    GameObject[] cropArray = new GameObject[] {};
    public float speed = 10f;
    int cropID = 1;
    float duration = 3;

    public override void EnterState(CrowStateManager crow){
        cropArray = GameObject.FindGameObjectsWithTag("corn");
        cropID = Random.Range(0, cropArray.Length);
        anim.Fly();
    }

    public override void UpdateState(CrowStateManager crow){
        crow.transform.position = Vector3.MoveTowards(crow.transform.position, cropArray[cropID].transform.position, speed * Time.deltaTime);
        //animation/ani state 
    }

    public override void OnCollisionEnter(CrowStateManager crow, Collision collision){
        Debug.Log("EAT");
        if(collision.gameObject.tag == "corn"){
            crow.SwitchState(crow.EatingState);
            
        }
        //The flashlight and slingshot are autoflee
        if(collision.gameObject.tag == "fl_collision" || collision.gameObject.tag == "ss_collision")
        {
            // crow.SwitchState(crow.FleeingState);
            Debug.Log("Flee");
        }
        if(collision.gameObject.tag == "hm_collision")
        {
            duration = 3;
        } 
    }

    //This is for the mirror, you have to hold the beam on the crow to make it flee
    public void OnCollisionStay(CrowStateManager crow, Collision collision)
    {
        if(collision.gameObject.tag == "hm_collision")
        {
            if(duration > 0)
            {
                duration -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Flee");
            }
        }
        
        
    }
}
