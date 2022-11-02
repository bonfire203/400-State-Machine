using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[System.Serializable]
public class DefaultRoom
{
    public string Name;
    public int sceneIndex;
    public int maxPlayer;
}
public class NetworkManager : MonoBehaviourPunCallbacks
{
    public List<DefaultRoom> defaultRooms;
    public GameObject roomUI;
    public bool lvlSetup = false;
    public SpawnCropManager cropSpawn;
    public Vector3 p1_spawnLocation = new Vector3(1.5f, 0.53f, -0.1f);
    public Vector3 p2_spawnLocation = new Vector3(0.07f, 0.53f, 1.23f);
    public Vector3 p3_spawnLocation = new Vector3(1.8f, 0.53f, -0.1f);

    public void Start()
    {
        //gameObject.AddComponent<SpawnCropManager>();
        //cropSpawn = GetComponent<SpawnCropManager>();
    }

    public void ConnectToServer()
    {
        Debug.Log("Trying to connect to server...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to server!");
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Joined the lobby");
        roomUI.SetActive(true);
    }

    public void InitiliazeRoom(int defaultRoomIndex)
    {
        DefaultRoom roomSettings = defaultRooms[defaultRoomIndex];

        //load scene
        PhotonNetwork.LoadLevel(roomSettings.sceneIndex);

        //Create the room
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)roomSettings.maxPlayer;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom(roomSettings.Name, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a Room");
        base.OnJoinedRoom();
        Debug.Log("Starting: " + PhotonNetwork.CurrentRoom.PlayerCount);
        if (PhotonNetwork.CurrentRoom.PlayerCount == 0)
        {
            PhotonNetwork.Instantiate("NetworkP1", p1_spawnLocation, transform.rotation);
            Debug.Log("first player " + PhotonNetwork.CurrentRoom.PlayerCount);
        }
        else if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.Instantiate("NetworkP2", p1_spawnLocation, transform.rotation);
            Debug.Log("second player " + PhotonNetwork.CurrentRoom.PlayerCount);
        }
        else if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            PhotonNetwork.Instantiate("NetworkP3", p1_spawnLocation, transform.rotation);
            Debug.Log("third player " + PhotonNetwork.CurrentRoom.PlayerCount);
        }
        else
        {
            PhotonNetwork.Instantiate("NetworkP1", p1_spawnLocation, transform.rotation);
            Debug.Log("extra " + PhotonNetwork.CurrentRoom.PlayerCount);
        }

        //if (!lvlSetup)
        //{
        //    cropSpawn.SpawnCrop();
        //    lvlSetup = true;
        //}


    }

    public override void OnPlayerEnteredRoom(Player other)
    {
        Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName); // not seen if you're the player connecting
        


        //if (PhotonNetwork.IsMasterClient)
        //{
        //    Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom


        //    InitiliazeRoom(1);
        //}
    }

    public override void OnPlayerLeftRoom(Player other)
    {
        Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName); // seen when other disconnects
       // PhotonNetwork.Destroy();

        //if (PhotonNetwork.IsMasterClient)
        //{
        //    Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom


        //    InitiliazeRoom(1);
        //}
    }
}
