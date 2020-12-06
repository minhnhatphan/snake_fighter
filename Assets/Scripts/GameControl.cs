using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;

public class GameControl : MonoBehaviourPunCallbacks
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject bananaPrefab;
    [SerializeField]
    private GameObject cheesePrefab;
    [SerializeField]
    private GameObject hamburgerPrefab;
    [SerializeField]
    private GameObject watermelonPrefab;
    // Start is called before the first frame update
#pragma warning restore 0649

    private int minDistance = -50;
    private int maxDistance = 50;

    //public GameObject playerPrefab;
    void Start()
    {
        PhotonNetwork.Instantiate("snake", Vector3.zero, Quaternion.identity);
        GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("head").transform;
        // Master client will instantiate fruits over the network to avoid duplication
        if (PhotonNetwork.IsMasterClient)
        {
            for(int i = 0;i < 8; i++)
            {
                PhotonNetwork.Instantiate(bananaPrefab.name, new Vector3(Random.Range(minDistance, maxDistance), 0.5f, Random.Range(minDistance, maxDistance)), Quaternion.identity);
                PhotonNetwork.Instantiate(cheesePrefab.name, new Vector3(Random.Range(minDistance, maxDistance), 0.5f, Random.Range(minDistance, maxDistance)), Quaternion.identity);
                PhotonNetwork.Instantiate(hamburgerPrefab.name, new Vector3(Random.Range(minDistance, maxDistance), 0.5f, Random.Range(minDistance, maxDistance)), Quaternion.identity);
                PhotonNetwork.Instantiate(watermelonPrefab.name, new Vector3(Random.Range(minDistance, maxDistance), 0.5f, Random.Range(minDistance, maxDistance)), Quaternion.identity);
            }
            
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
