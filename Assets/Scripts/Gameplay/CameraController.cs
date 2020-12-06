using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


    public GameObject mainCamera;
    public GameObject snakeHead;
    private Vector3 initialPos;
	private Vector3 initialRotation;
	


	//CAMERA POSITIONS
	enum CameraPosition {close, middle, far};

	//current camera position
	CameraPosition currentPos;

	// Use this for initialization
	void Start () {
		initializeCameraDetails();
	}

	//Initial camera details
	void initializeCameraDetails(){
		//initial camera position
		currentPos = CameraPosition.close;

		//camera initial position and rotation
        //
		initialPos = new Vector3(mainCamera.transform.localPosition.x, mainCamera.transform.localPosition.y, mainCamera.transform.localPosition.z);
		initialRotation = new Vector3(mainCamera.transform.localRotation.eulerAngles.x, mainCamera.transform.localRotation.eulerAngles.y, mainCamera.transform.localRotation.eulerAngles.z);
		
	}

	//change position of the camera
	public void changeCameraPosition(){
		if (currentPos == CameraPosition.close){
			currentPos = CameraPosition.middle;

			Transform newTransform = snakeHead.transform;
			Vector3 newPosition = newTransform.position;
			mainCamera.transform.rotation = newTransform.rotation;
			mainCamera.transform.position = newPosition;
		
		}else if(currentPos == CameraPosition.middle){
			currentPos = CameraPosition.far;

			mainCamera.transform.localRotation = Quaternion.Euler(initialRotation.x, initialRotation.y, initialRotation.z);
			mainCamera.transform.localPosition = new Vector3(initialPos.x, initialPos.y + 2f, initialPos.z - 3f);
			Debug.Log(initialPos + "   " + initialRotation.y);
		
		}else if(currentPos == CameraPosition.far){
            currentPos = CameraPosition.close;

			mainCamera.transform.localRotation = Quaternion.Euler(initialRotation.x, initialRotation.y, initialRotation.z);
			mainCamera.transform.localPosition = initialPos;
			
		}
	}
}
