using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using Photon.Pun;
using Photon.Realtime;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timeDisplay = null;

    bool startTimer = false;
    double timerIncrementValue;
    double startTime = 0;
    private double timer;
    

    ExitGames.Client.Photon.Hashtable CustomeValue;

    // Start is called before the first frame update
    void Start()
    {
        timer = MasterManager.GameSettings.Timer;
        if (PhotonNetwork.IsMasterClient)
        {
            CustomeValue = new ExitGames.Client.Photon.Hashtable();
            startTime = PhotonNetwork.Time;
            startTimer = true;
            CustomeValue.Add("StartTime", startTime);
            PhotonNetwork.CurrentRoom.SetCustomProperties(CustomeValue);
        }
        else
        {        
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("StartTime"))
            {
                startTime = double.Parse(PhotonNetwork.CurrentRoom.CustomProperties["StartTime"].ToString());
            }
            
            startTimer = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!startTimer) return;

        if ((startTime==0)&&(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("StartTime")))
        {
            startTime = double.Parse(PhotonNetwork.CurrentRoom.CustomProperties["StartTime"].ToString());
        }
        
        timerIncrementValue = timer - (PhotonNetwork.Time - startTime);
        timeDisplay.text = string.Format("{0:00}",timerIncrementValue);
        if ((startTime!=0)&&(timerIncrementValue < 0))
        {
            //Timer Completed
            //Do What Ever You What to Do Here
            int thisPlayerScore = (int)PhotonNetwork.LocalPlayer.CustomProperties["score"];
            int otherPlayerScore = 0;
            if (PhotonNetwork.PlayerListOthers.Length > 0)
            {
                Player otherplayer = PhotonNetwork.PlayerListOthers[0];
                otherPlayerScore = (int)otherplayer.CustomProperties["score"];
            }

            if (thisPlayerScore > otherPlayerScore)
            {
                MasterManager.GameSettings.Draw = false;
                MasterManager.GameSettings.Win = true;
            }
            else if (thisPlayerScore < otherPlayerScore)
            {
                MasterManager.GameSettings.Draw = false;
                MasterManager.GameSettings.Win = false;
            }
            else
            {
                MasterManager.GameSettings.Draw = true;
            }
            PhotonNetwork.LeaveRoom();
            startTimer = false;
        }
    }
}
