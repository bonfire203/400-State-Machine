using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CrowStateManager : MonoBehaviourPunCallbacks
{
    CrowBaseState currentState;
    public CrowFleeingState FleeingState = new CrowFleeingState();
    public CrowEatingState EatingState = new CrowEatingState();
    public CrowTravelState TravelState = new CrowTravelState();
    public CrowAnimations CrowAnim;
    public GameObject crowGO;
    // Start is called before the first frame update
    void Start()
    {
        CrowAnim = GetComponent<CrowAnimations>();
        crowGO = gameObject;
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

    void OnTriggerEnter(Collider other){
        currentState.OnTriggerEnter(this, other);
    }

    public void DestroyCrow(GameObject crow)
    {
        PhotonNetwork.Destroy(crow);
    }

    public void DestroyCorn(GameObject corn)
    {
        PhotonNetwork.Destroy(corn);
    }
}
