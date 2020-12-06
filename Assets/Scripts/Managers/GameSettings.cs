using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Manager/GameSettings")]
public class GameSettings : ScriptableObject
{
    
    [SerializeField]
    private string _gameVersion = "0.0.1";
    public string GameVersion {get {return _gameVersion;} }
    [SerializeField]
    private string _nickName = "Player";
    [SerializeField]
    private byte _maxPlayer = 2;
    [SerializeField]
    private byte _numberOfMaps = 3;
    [SerializeField]
    private byte _timer = 90;
    [SerializeField]
    private byte _scoreFruit = 10;


    [SerializeField]
    private bool _win = true;
    [SerializeField]
    private bool _draw = false;

    public string NickName {
        get {
            int value = Random.Range(0, 9999);
            return _nickName + value.ToString();
        } 
    }

    public bool Win {
        get { return _win; }
        set { _win = value; }
    }

    public bool Draw
    {
        get { return _draw; }
        set { _draw = value; }
    }
    public byte MaxPlayer{ get{ return _maxPlayer; } }
    public byte NumberOfMaps{ get{ return _numberOfMaps; } }
    public byte Timer { get { return _timer; } }
    public byte ScoreFruit { get { return _scoreFruit; } }
}
