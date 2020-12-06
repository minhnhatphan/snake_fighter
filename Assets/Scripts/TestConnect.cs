using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TestConnect : MonoBehaviourPunCallbacks
{
    private void Start(){
        Debug.Log("Connecting to serverTest.");
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
       if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        PhotonNetwork.AutomaticallySyncScene = true;
       

    }

    public override void OnConnectedToMaster(){
        Debug.Log("Connected to serverMaster.");
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);

        if (!PhotonNetwork.InLobby){
            PhotonNetwork.JoinLobby();
        }


        

    }

    public override void OnDisconnected(DisconnectCause cause){
        Debug.Log("Disconnected from server for reason " + cause.ToString());

    }

}
