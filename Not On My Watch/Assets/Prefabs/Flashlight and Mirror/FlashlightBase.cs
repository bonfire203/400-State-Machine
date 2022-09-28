using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlashlightBase : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "crate")
        {
            Debug.Log("start new level");
            //spawn with more corn
            SceneManager.LoadScene("Main");
        }
    }
}
