using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowAnimations : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void AttackCorn(CrowStateManager crow) {
        //this one automatically flows into eat
        Animator anim = crow.GetComponent<Animator>();
        anim.SetTrigger("AttackCorn");
    }

    public void Fly(CrowStateManager crow) {
        Animator anim = crow.GetComponent<Animator>();
        anim.SetTrigger("Fly");
    }
}
