using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowAnimations : MonoBehaviour
{
    Animator anim;

    void Update()
    {
        anim = GetComponent<Animator>();
    }

    public void AttackCorn() {
        anim = GetComponent<Animator>();
        //this one automatically flows into eat
        anim.SetTrigger("AttackCorn");
    }

    public void Fly() {
        anim = GetComponent<Animator>();
        anim.SetTrigger("Fly");
    }
}
