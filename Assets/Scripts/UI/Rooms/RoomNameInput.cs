using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomNameInput : MonoBehaviour
{
    [SerializeField]
    private Button _createRoomButton = null;
    [SerializeField]
    private TMP_Text _roomNameText = null;

    public void SetButtonState(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            _createRoomButton.interactable = false;
        }
        else
        {
            _createRoomButton.interactable = true;
            
        }
    }

    public void SetRoomNameText(string value)
    {
        _roomNameText.text = "Room: " + value;
    }

}
