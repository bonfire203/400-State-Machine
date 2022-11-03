using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class SpawnCrowManager : MonoBehaviourPunCallbacks
{
    public GameObject prefab;
    readonly float MAX_CORN_SPAWN = 216f;
    // Start is called before the first frame update
    public override void OnJoinedRoom()
    {
        if(SceneManager.GetActiveScene().name == "mainV2")
        {
            StartCoroutine(SpawnCrow());
        }
        
    }

    IEnumerator SpawnCrow(){
        while (GameObject.FindGameObjectsWithTag("crow").Length < 20)
        {
            yield return new WaitForSeconds(5f);
            //determine spawn time to scale
            float cornNum = MainManager.Instance.cornStart;
            float factor = (MAX_CORN_SPAWN - cornNum) / 10;
            Vector3 pos = new Vector3(Random.Range(25f, 50f), Random.Range(10f, 20f), Random.Range(25f, 50f));
            GameObject myCrow = PhotonNetwork.Instantiate("Crow", pos, Quaternion.identity);
            myCrow.tag = "crow";
            //Debug.Log(factor);
            //StartCoroutine(SpawnCrow());  
        }
    }
}
