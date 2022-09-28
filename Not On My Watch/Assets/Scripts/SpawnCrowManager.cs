using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrowManager : MonoBehaviour
{
    public GameObject prefab;
    readonly float MAX_CORN_SPAWN = 216f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCrow());   
    }

    IEnumerator SpawnCrow(){
        //determine spawn time to scale
        float cornNum = MainManager.Instance.cornStart;
            float factor = (MAX_CORN_SPAWN - cornNum) / 10;
            Vector3 pos = new Vector3(Random.Range(25f, 50f), Random.Range(10f, 20f), Random.Range(25f, 50f));
            GameObject myCrow = Instantiate(prefab, pos, Quaternion.identity);
            Debug.Log(factor);
            yield return new WaitForSeconds(5f);
            StartCoroutine(SpawnCrow());  
    }
}
