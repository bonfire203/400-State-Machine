using UnityEngine;
using Photon.Pun;
public abstract class CrowBaseState : MonoBehaviourPun
{
    public abstract void EnterState(CrowStateManager crow);
    
    public abstract void UpdateState(CrowStateManager crow);

    public abstract void OnTriggerEnter( Collider other);
}
