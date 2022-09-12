using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCropManager : MonoBehaviour
{
    //public GameObject TargetObject;

    public GameObject cropObj;
    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < 10; i ++){
            Vector3 spawnPos = new Vector3(Random.Range(20, 0), 3, Random.Range(20, 0));
            Instantiate(cropObj, spawnPos, Quaternion.identity);
        }
    }
}
