using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightBase : MonoBehaviour
{
    private float timeRemaining = 10;
    private bool timerRunning = false;
    private float cooldownRemaining = 5;
    private bool cooldownRunning = false;
    void Start() {
        timeRemaining = 10;
        timerRunning = true;
        cooldownRemaining = 5;
        cooldownRunning = false;
    }
    void Update()
    {
        //if the object is picked up, assume it's on
        //after 10 seconds, turn it off for a bit, even if picked back up
        if (timerRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time to Cooldown");
                //Turn off collider and light
                transform.GetChild(0).GetComponent<Collider>().enabled = false;
                transform.GetChild(1).GetComponent<Light>().enabled = false;
                timeRemaining = 0;
                timerRunning = false;
                cooldownRemaining = 5;
                cooldownRunning = true;
            }
        }
        if(cooldownRunning)
        {
            if(cooldownRemaining > 0)
            {
                cooldownRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Ready to pick back up again");
                //Turn on collider and light
                transform.GetChild(0).GetComponent<Collider>().enabled = true;
                transform.GetChild(1).GetComponent<Light>().enabled = true;
                cooldownRemaining = 0;
                cooldownRunning = false;
                timeRemaining = 10;
                timerRunning = true;
            }
        }
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
