using UnityEngine;
using System.Collections;
using Photon.Pun;

public class FruitRotator : MonoBehaviour {

    private GameObject snakeObject;
    private int minDistance = -8;
    private int maxDistance = 8;
    private Vector3 newPosition;
    private string[] listFruit;
    PhotonView photonView;

    //score
    public static int count;

    public Vector3 NewPosition { get { return newPosition; } }

    // Use this for initialization
    void Awake()
    {
        listFruit = new string[4] { "Banana", "Cheese", "Hamburger", "Watermelon" };
    }

    void Start () {

        
        
		//initialize counter
		count = 0;


		//new position
		newPosition = new Vector3(Random.Range(minDistance, maxDistance), 0.5f, Random.Range(minDistance, maxDistance));
        photonView = PhotonView.Get(this); 
    }
	
	// Update is called once per frame
	void Update () {
        snakeObject = GameObject.Find("snake(Clone)");
        if (snakeObject == null)
        {
            return;
        }
        transform.Rotate(new Vector3(0, 120, 0) * Time.deltaTime);
	}

	//add body part when colliding with head
	void OnTriggerEnter(Collider other){
		if (PhotonNetwork.IsMasterClient && other.gameObject.CompareTag("Head")){
            print("touch");
            //Check if the snake is mine
            GameObject snake_parent = other.gameObject.transform.parent.gameObject;
            if (snake_parent.GetComponent<PhotonView>().IsMine)
            {
                snake_parent.GetComponent<TestMovement>().addBodyPart();
            }
            else
            {
                
                photonView.RPC("addBodyPartSnake", RpcTarget.Others, snake_parent.GetPhotonView().ViewID);
            }
            

            // snakeObject.GetComponent<TestMovement>().addBodyPart();

            //get new position
            // StartCoroutine(getNewPosition());    
            newPosition = new Vector3(Random.Range(minDistance, maxDistance), 0.5f, Random.Range(minDistance, maxDistance));

            //hide apple
            PhotonNetwork.Destroy(this.gameObject);

            string randomFruit = listFruit [Random.Range(0, listFruit.Length)];


            //show apple in new position
            PhotonNetwork.Instantiate(randomFruit, newPosition, Quaternion.identity);

            //increase score counter
            count++;
            Debug.Log(count);
            
            
		}
	}

	//get new position for spawn
	public IEnumerator getNewPosition(){
		while(Physics.CheckSphere(newPosition, 1.0f)){
			newPosition = new Vector3(Random.Range(minDistance, maxDistance), 0.5f, Random.Range(minDistance, maxDistance));
			yield return null;
		}
	}
    
    [PunRPC]
    public void addBodyPartSnake(int snake_id)
    {
        Debug.Log(string.Format("RPC received ID: {0}", snake_id));
        PhotonView.Find(snake_id).gameObject.GetComponent<TestMovement>().addBodyPart();
    }

}
