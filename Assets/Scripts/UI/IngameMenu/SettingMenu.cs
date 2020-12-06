using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject settingPanel = null;

    private bool Paused = false;
    private bool win;

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (Paused)
            {
                changePanel(false);
            }
            else
            {
                changePanel(true);
            }
        }
    }

    public void Onclick_Resume()
    {
        changePanel(false);
    }

    public void OnClick_PauseSetting()
    {
        changePanel(true);
    }

    public void OnClick_Resign()
    {
        MasterManager.GameSettings.Win = false;
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel(4);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        MasterManager.GameSettings.Win = true;
        PhotonNetwork.LeaveRoom();
    }

    void changePanel(bool state)
    {
        settingPanel.SetActive(state);
        Paused = state;
    }
}
