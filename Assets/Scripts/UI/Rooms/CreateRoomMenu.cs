using UnityEngine;
using UnityEngine.UI;

using Photon.Realtime;
using Photon.Pun;
public class CreateRoomMenu : TestConnect
{
    [SerializeField]
    private Text _roomname = null;

    private RoomsCanvases _roomCanvases;
    public void FirstInitialize(RoomsCanvases canvases){
        _roomCanvases = canvases;
    }
    public void OnClick_CreateRoom(){
        if (!PhotonNetwork.IsConnected){
            return;
        }
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = MasterManager.GameSettings.MaxPlayer;
        if (PhotonNetwork.NickName.Length == 0){
            PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        }
        PhotonNetwork.JoinOrCreateRoom(_roomname.text, options, TypedLobby.Default);
    }

    public void OnClick_ReturnToStartMenu()
    {
        _roomCanvases.StartMenuCanvas.Show();
        _roomCanvases.CreateOrJoinRoomCanvas.Hide();
    }

    public override void OnCreatedRoom(){
        Debug.Log("Created room sucessfully.");
        _roomCanvases.CurrentRoomCanvas.Show();
    }
    public override void OnCreateRoomFailed(short returnCode, string message){
        Debug.Log("Created room failed.");
    }
}
