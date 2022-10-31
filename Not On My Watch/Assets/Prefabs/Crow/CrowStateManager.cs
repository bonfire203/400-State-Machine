using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowStateManager   : MonoBehaviour
{
    CrowBaseState currentState;
    public CrowFleeingState FleeingState = new CrowFleeingState();
    public CrowEatingState EatingState = new CrowEatingState();
    public CrowTravelState TravelState = new CrowTravelState();
    public CrowAnimations CrowAnim;
    // Start is called before the first frame update
    void Start()
    {
        CrowAnim = GetComponent<CrowAnimations>();
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

    public void DestroyCrow()
    {
        Destroy(gameObject, 5f);
    }

    public void DestroyCorn(GameObject corn)
    {
        Destroy(corn);
    }
}
