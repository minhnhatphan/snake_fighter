using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Cinemachine;

public class MyPhoton : TestConnect
{
    // Start is called before the first frame update
    void Start()
    {
        print("Hello I'm instantiatePhoton");
        PhotonNetwork.ConnectUsingSettings();
    }

    public  override void OnConnectedToMaster()
    {

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, null);
        print("Hello I'm instantiatemaster");

    }

    public override void OnJoinedRoom()
    {
        print("Hello I'm instantiateRoom");
        GameObject newPlayer = PhotonNetwork.Instantiate("snake", Vector3.zero, Quaternion.identity);
        GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("head").transform;
    }

    
}
