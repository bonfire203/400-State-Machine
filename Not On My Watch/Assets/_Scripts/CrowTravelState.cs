using UnityEngine;

public class CrowTravelState : CrowBaseState
{
    //public CrowAnimations anim = new CrowAnimations();
    GameObject[] cropArray = new GameObject[] {};
    GameObject cornChild;
    GameObject cornStalkChild;

    public float speed = 10f;
    int cropID = 1;
    float duration = 3;

    public override void EnterState(CrowStateManager crow){
        cropArray = GameObject.FindGameObjectsWithTag("corn");
        cropID = Random.Range(0, cropArray.Length);
        cornStalkChild = cropArray[cropID].transform.GetChild(0).gameObject;
        int randomCorn = Random.Range(1, 4);
        cornChild = cropArray[cropID].transform.GetChild(randomCorn).gameObject;
        
    }

    public override void UpdateState(CrowStateManager crow){
        if(cornChild != null)
        {
            crow.transform.position = Vector3.MoveTowards(crow.transform.position, cornChild.transform.position, speed * Time.deltaTime);
        }
        else
        {
            crow.SwitchState(crow.TravelState);
        }
    }

    public override void OnTriggerEnter(Collider collision){
        CrowStateManager crow = gameObject.GetComponent<CrowStateManager>();

        if (collision.gameObject.tag == "corn"){
           
            crow.SwitchState(crow.EatingState);
            //crow.SwitchState(crow.EatingState);
        }
        //The flashlight and slingshot are autoflee
        if(collision.gameObject.tag == "fl_collision" || collision.gameObject.tag == "ss_collision")
        {
            Debug.Log("Flee now");
            crow.SwitchState(crow.FleeingState);
        }
        if(collision.gameObject.tag == "hm_collision")
        {
            duration = 3;
        } 

    }

    //This is for the mirror, you have to hold the beam on the crow to make it flee
    //public override void OnCollisionStay(CrowStateManager crow, Collider collision)
    //{
    //    if(collision.gameObject.tag == "hm_collision")
    //    {
    //        if(duration > 0)
    //        {
    //            duration -= Time.deltaTime;
    //        }
    //        else
    //        {
    //            crow.SwitchState(crow.FleeingState);
    //        }
    //    }
    //}
}
