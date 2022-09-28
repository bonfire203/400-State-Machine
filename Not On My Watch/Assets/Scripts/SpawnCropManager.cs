using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCropManager : MonoBehaviour
{
    //public GameObject TargetObject;
    public int spawnLimit;
    public GameObject prefab;
    readonly float MAX_CORN_SPAWN = 216f;
    readonly int SPAWN_BUFFER = 2;

    private Vector3 playerVec = new Vector3(0f,0f,0f);
    // Start is called before the first frame update
    void Awake()
    {
        //basically just checking if this is the first instance or not.
        //spawnLimit = MainManager.Instance.cornStart;
        if(spawnLimit < 1){
            spawnLimit = 5;
        }

        //determine everthing radius/angle etc
        Vector3 center = playerVec;
        float nAngle = returnAngle();
        for(int radius = 0; radius < 6; radius++){
            for(int angle = 10; angle <= nAngle; angle+=10){
                Vector3 pos = RandomCircle(center, radius + SPAWN_BUFFER, angle);
                Vector3 rot = new Vector3(0, Random.Range(0, 360), 0);
                float randomXZ = Random.Range(0, 3);
                float randomY = Random.Range(0, 3);
                GameObject myCrop = Instantiate(prefab, pos, rot);
                myCrop.transform.localScale = new Vector3(randomXZ, randomY, randomXZ);
            }
        }
    }

    float returnAngle(){
        float cornNum = MainManager.Instance.cornStart;
        float percent = cornNum/MAX_CORN_SPAWN;
        Debug.Log(percent);
        float actualAngle = percent*360;
        Debug.Log(actualAngle);
        return actualAngle;
    }

    Vector3 RandomCircle (Vector3 center, float radius, float angle){
         Vector3 pos;
         pos.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
         pos.y = center.y;
         pos.z = center.z + + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
         return pos;
     }
}
