using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    private RoomsCanvases _roomCanvases;

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomCanvases = canvases;
    }

    public void OnClick_JoinLobby()
    {
        ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable();
        hash.Add("score",0);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);

        _roomCanvases.CreateOrJoinRoomCanvas.Show();
        _roomCanvases.StartMenuCanvas.Hide();
    }

    
}
