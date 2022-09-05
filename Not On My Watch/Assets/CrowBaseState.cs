using UnityEngine;

public abstract class CrowBaseState
{
    public abstract void EnterState(CrowStateManager crow);
    
    public abstract void UpdateState(CrowStateManager crow);

    public abstract void OnCollisionEnter(CrowStateManager crow);
}
