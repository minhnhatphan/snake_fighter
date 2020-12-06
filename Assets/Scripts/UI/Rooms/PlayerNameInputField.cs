using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

[RequireComponent(typeof(InputField))]
public class PlayerNameInputField : MonoBehaviour
{
    [SerializeField]
    private Button _startGameButton = null;
    
    const string playerNamePrefKey = "PlayerName";
    // Start is called before the first frame update
    void Start()
    {
        string defaultName = string.Empty;
        InputField _inputField = this.GetComponent<InputField>();
        if (_inputField!=null){
            if (PlayerPrefs.HasKey(playerNamePrefKey)){
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                _inputField.text = defaultName;
            }
        }

        PhotonNetwork.NickName = defaultName;
    }

    public void SetPlayerName(string value){
        if (string.IsNullOrEmpty(value)){
            Debug.LogError("Player Name is null or empty");
        }
        
        PhotonNetwork.NickName = value;
        PlayerPrefs.SetString(playerNamePrefKey, value);
    }

    public void SetButtonState(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            _startGameButton.interactable = false;
        }
        else
        {
            _startGameButton.interactable = true;
        }
    }
}
