using UnityEngine;
using System.Collections;
using Photon.Pun;

public class HeadCollision : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		Debug.Log("Head Trigger");

		//collide with bodyPart
		if(other.gameObject.CompareTag("BodyPart")){
			Debug.Log("Triggred With BodyPart");
            //goto lose screen
            MasterManager.GameSettings.Draw = false;
            MasterManager.GameSettings.Win = false;
            PhotonNetwork.LeaveRoom();
		}
	}

}
