using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCropManager : MonoBehaviour
{
    //public GameObject TargetObject;
    public int spawnLimit;
    public GameObject prefab;

    private Vector3 playerVec = new Vector3(0f,0f,0f);
    // Start is called before the first frame update
    void Awake()
    {
        //basically just checking if this is the first instance or not.
        //spawnLimit = MainManager.Instance.cornStart;
        if(spawnLimit < 1){
            spawnLimit = 5;
        }

        float angle = DetermineAngle();
        float radius = DetermineRadius();
        Vector3 center = playerVec;
        
        for(int i = 0; i < 100; i ++){
            for(int row = 1; row <= 36; i++){
                Vector3 pos = RandomCircle(center, radius, row * 10);
                Instantiate(prefab, pos, Quaternion.identity);
            }
            
        
        }
    }

    private float DetermineAngle(){
        //int num = MainManager.Instance.cornStart;
        return 360;
        /*if(num > 500){
            return 360;
        }else if(num <= 500 && num > 250){
            return 270;
        }else if(num <= 250 && num > 100){
            return 180;
        }else{
            return 90;
        }*/
    }

    private float DetermineRadius(){
        return 5;
    }

    Vector3 RandomCircle (Vector3 center, float radius, float angle){
         float ang = angle;//Random.value * angle;
         float nRadius = (Random.value * radius) + 2;
         Vector3 pos;
         pos.x = center.x + nRadius * Mathf.Sin(ang * Mathf.Deg2Rad);
         pos.y = center.y;
         pos.z = center.z + + nRadius * Mathf.Cos(ang * Mathf.Deg2Rad);
         return pos;
     }
}
