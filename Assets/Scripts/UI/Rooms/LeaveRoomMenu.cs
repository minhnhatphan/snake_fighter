using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class LeaveRoomMenu : MonoBehaviour
{
    private RoomsCanvases _roomCanvases;
    public void FirstInitialize(RoomsCanvases canvases){
        _roomCanvases = canvases;
    }

    public void Onclick_LeaveRoom(){
        PhotonNetwork.LeaveRoom(true);
        _roomCanvases.CreateOrJoinRoomCanvas.Show();
        _roomCanvases.CurrentRoomCanvas.Hide();
    }

}
