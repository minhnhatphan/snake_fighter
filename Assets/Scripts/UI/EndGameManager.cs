using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text announceText = null;

    private void Awake()
    {
        if (MasterManager.GameSettings.Draw)
        {
            announceText.text = "Draw!";
        }
        else
        {
            if (MasterManager.GameSettings.Win)
            {
                announceText.text = "You Win!";
            }
            else            
            {
                announceText.text = "You Lost!";
            }            
        }
        
    }
}
