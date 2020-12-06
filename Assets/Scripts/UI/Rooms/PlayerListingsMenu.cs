using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content = null;
    [SerializeField]
    private PlayerListing _playerListing = null;
    [SerializeField]
    
    private List<PlayerListing> _listings = new List<PlayerListing>();
    private RoomsCanvases _roomCanvases;

    public override void OnEnable(){
        base.OnEnable();
        GetCurrentRoomPlayer();
    }

    public override void OnDisable()
    {
        base.OnDisable();
        for (int i=0 ;i<_listings.Count;i++){
            Destroy(_listings[i].gameObject);
        }
        _listings.Clear();
    }
    
    public void FirstInitialize(RoomsCanvases canvases){
        _roomCanvases = canvases;
    }

    private void GetCurrentRoomPlayer(){
        if (!PhotonNetwork.IsConnected){
            return;
        }
        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null){
            return;
        }

        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players){
            AddPlayerListing(playerInfo.Value);
        }
        
    }

    private void AddPlayerListing(Player player){
        int index = _listings.FindIndex(x => x.Player == player);
        if (index!=-1){
            _listings[index].SetPlayerInfo(player);
        }
        else{
            PlayerListing listing = Instantiate(_playerListing, _content);
            if (listing != null){
                listing.SetPlayerInfo(player);
                _listings.Add(listing);
            }
        }
        
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        _roomCanvases.CurrentRoomCanvas.LeaveRoomMenu.Onclick_LeaveRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer){
        AddPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer){
        int index = _listings.FindIndex(x=> x.Player == otherPlayer);
        if (index != -1){
            Destroy(_listings[index].gameObject);
            _listings.RemoveAt(index);
        }
    }

    public void OnClick_StartGame(){
        if (PhotonNetwork.IsMasterClient){
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            int roomLevel = Random.Range(1, MasterManager.GameSettings.NumberOfMaps + 1);
            roomLevel = 2;
            Debug.Log(string.Format("Loading room Level: {0}", roomLevel));
            PhotonNetwork.LoadLevel(roomLevel);
        }
    }

}
