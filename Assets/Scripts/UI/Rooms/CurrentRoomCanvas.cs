﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private PlayerListingsMenu _playerListingsMenu = null;
    [SerializeField]
    private LeaveRoomMenu _leaveRoomMenu = null;
    public LeaveRoomMenu LeaveRoomMenu{get {return _leaveRoomMenu;}}

    private RoomsCanvases _roomCanvases;
    public void FirstInitialize(RoomsCanvases canvases){
        _roomCanvases = canvases;
        _playerListingsMenu.FirstInitialize(canvases);
        _leaveRoomMenu.FirstInitialize(canvases);
    }

    public void Show(){
        gameObject.SetActive(true);
    }

    public void Hide(){
        gameObject.SetActive(false);
    }
}
