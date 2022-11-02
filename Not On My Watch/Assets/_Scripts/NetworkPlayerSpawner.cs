using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    public Vector3 p1_spawnLocation = new Vector3(0f, 0f, 0f);
    public Vector3 p2_spawnLocation = new Vector3(0f, 0f, 2f);
    public Vector3 p3_spawnLocation = new Vector3(-2f, 0f, 1f);
    public int count = 0;
    private GameObject spawnedPlayerPrefab;
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        
        if(count == 0)
        {
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("NetworkP1", p1_spawnLocation, transform.rotation);
            count += 1;
        }
        else if (count == 1)
        {
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("NetworkP2", p2_spawnLocation, transform.rotation);
            count += 1;
        }
        else if (count == 2)
        {
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("NetworkP3", p3_spawnLocation, transform.rotation);
            count += 1;
        }
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
        count -= 1;
    }
}
