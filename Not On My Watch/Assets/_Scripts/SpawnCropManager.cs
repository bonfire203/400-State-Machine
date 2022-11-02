using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnCropManager : MonoBehaviourPunCallbacks
{
    //public GameObject TargetObject;
    public int spawnLimit;
    public GameObject prefab;
    readonly float MAX_CORN_SPAWN = 216f;
    readonly int SPAWN_BUFFER = 2;

    private Vector3 playerVec = new Vector3(0f,0f,0f);
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnCrop", 8);
    }

    float returnAngle(){
        float cornNum = MainManager.Instance.cornStart;
        float percent = cornNum/MAX_CORN_SPAWN;
        float actualAngle = percent*360;
        return actualAngle;
    }

    Vector3 RandomCircle (Vector3 center, float radius, float angle){
         Vector3 pos;
         pos.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
         pos.y = center.y;
         pos.z = center.z + + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
         return pos;
    }

    void SpawnCrop()
    {

        //basically just checking if this is the first instance or not.
        //spawnLimit = MainManager.Instance.cornStart;
        if (spawnLimit < 1)
        {
            spawnLimit = 5;
        }

        //determine everthing radius/angle etc
        Vector3 center = playerVec;
        float nAngle = returnAngle();
        for (int radius = 0; radius < 6; radius++)
        {
            for (int angle = 10; angle <= nAngle; angle += 10)
            {
                Vector3 pos = RandomCircle(center, radius + SPAWN_BUFFER, angle);
                Quaternion rot = Quaternion.Euler(0, Random.Range(0f, 270f), 0); ;
                float randomXYZ = Random.Range(.85f, 1.25f);

                GameObject myCrop = PhotonNetwork.Instantiate("Crop", pos, rot);
                myCrop.transform.localScale = new Vector3(randomXYZ, randomXYZ, randomXYZ);
            }
        }
    }
}
