using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowAnimations : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void AttackCorn() {
        //this one automatically flows into eat
        anim.SetTrigger("AttackCorn");
    }

    public void Fly() {
        anim.SetTrigger("Fly");
    }
}
