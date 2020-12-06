using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text your_score = null;
    [SerializeField]
    private TMP_Text opponent_score = null;

    // Start is called before the first frame update
    void Start()
    {
        UpdateTextScore();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTextScore();
    }

    private void UpdateTextScore()
    {
        your_score.text = string.Format("Your score: {0}", PhotonNetwork.LocalPlayer.CustomProperties["score"].ToString());
        if (PhotonNetwork.PlayerListOthers.Length > 0)
        {
            Player otherplayer = PhotonNetwork.PlayerListOthers[0];
            Debug.Log(string.Format("Other Player score: {0}", otherplayer.CustomProperties["score"].ToString()));
            opponent_score.text = string.Format("Opponent score: {0}", otherplayer.CustomProperties["score"].ToString());
        }
        else
        {
            Debug.Log("No player");
            opponent_score.text = "Opponent score: 0";
        }

    }
}
