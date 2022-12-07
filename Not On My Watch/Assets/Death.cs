using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider col)
    {
        Debug.Log(PhotonNetwork.CurrentRoom.Name);
        Debug.Log(PhotonNetwork.IsMasterClient);
        if (PhotonNetwork.IsMasterClient) PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        Invoke("LeaveRoom", 2f);
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LoadLevel(0);
    }
}
