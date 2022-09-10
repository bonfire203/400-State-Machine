using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightBase : MonoBehaviour
{
    void Update()
    {
        //if the object is picked up, assume it's on
        //after 5 seconds, turn it off for a bit, even if picked back up

    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "crow")
        {
            //change state of the crow to fly away
            //crow must have "crow" tag and a rigidbody
            Debug.Log("Hit a crow");
        }
    }
}
