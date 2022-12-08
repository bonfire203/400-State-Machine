using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnObjectPhoton : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Awake()
    {
        //PhotonNetwork.Instantiate(prefab.name, new Vector3(0, 1, 2), Quaternion.identity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
