using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowStateManager   : MonoBehaviour
{
    int counter = 0;
    CrowBaseState currentState;
    public CrowFleeingState FleeingState = new CrowFleeingState();
    public CrowEatingState EatingState = new CrowEatingState();
    public CrowTravelState TravelState = new CrowTravelState();
    // Start is called before the first frame update
    void Start()
    {
        currentState = TravelState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(CrowBaseState state){
        currentState = state;
        state.EnterState(this);
    }

    void OnCollisionEnter(Collision collision){
        currentState.OnCollisionEnter(this, collision);
    }

    public string CountDown(){
        StartCoroutine(DoCountDown()); 
        return "";  
    }

    IEnumerator DoCountDown(){
        counter++;
        if(counter >= 10){
            Debug.Log("Done Eating");
        }
        Debug.Log("Continue Eating");
        yield return new WaitForSeconds(5f);
        StartCoroutine(CountDown());  
    }
}
