using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrowManager : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator SpawnCrow(){
        
        GameObject myCrow = Instantiate(prefab, pos, Quaternion.Euler( 0, Random.Range( 0, 360 ), 0 ));
        
    }
}
