using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CrowStateManager : MonoBehaviourPunCallbacks
{
    CrowBaseState currentState;
    public CrowFleeingState FleeingState;
    public CrowEatingState EatingState;
    public CrowTravelState TravelState;
    public CrowAnimations CrowAnim;
    public GameObject crowGO;
    // Start is called before the first frame update
    void Start()
    {
        CrowAnim = GetComponent<CrowAnimations>();
        FleeingState = gameObject.AddComponent<CrowFleeingState>();
        EatingState = gameObject.AddComponent<CrowEatingState>();
        TravelState = gameObject.AddComponent<CrowTravelState>();
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
        currentState.OnTriggerEnter(other);
    }

    public void DestroyCrow(GameObject crow)
    {
        PhotonNetwork.Destroy(crow);
    }

    public void DestroyCorn(GameObject corn)
    {
        PhotonNetwork.Destroy(corn);
    }

    public IEnumerator Delay(GameObject crow)
    {
        yield return new WaitForSeconds(5);
        DestroyCorn(crow);
    }

    public void StartDeath(GameObject crow)
    {
        StartCoroutine(Delay(crow));
    }
}
