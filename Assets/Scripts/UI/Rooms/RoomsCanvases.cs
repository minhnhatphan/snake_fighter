using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsCanvases : MonoBehaviour
{
    [SerializeField]
    private CreateOrJoinRoomCanvas _createOrJoinRoomCanvas = null;
    public CreateOrJoinRoomCanvas CreateOrJoinRoomCanvas{get {return _createOrJoinRoomCanvas;}}

    [SerializeField]
    private CurrentRoomCanvas _currentRoomCanvas = null;
    public CurrentRoomCanvas CurrentRoomCanvas{get {return _currentRoomCanvas;}}

    [SerializeField]
    private StartMenuCanvas _startMenuCanvas = null;
    public StartMenuCanvas StartMenuCanvas { get { return _startMenuCanvas; } }

    private void Awake(){
        FirstInitialize();
    }

    private void FirstInitialize(){
        CreateOrJoinRoomCanvas.FirstInitialize(this);
        CurrentRoomCanvas.FirstInitialize(this);
        StartMenuCanvas.FirstInitialize(this);
    }
}
