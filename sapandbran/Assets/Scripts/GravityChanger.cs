using UnityEngine;
using System.Collections;

public class GravityChanger : MonoBehaviour {
	public bool goThroughFloor;
	public GameObject currentPlatform;
	//public Vector3 moveDirection;
	public GameObject player;
	//private bool isMovingBack = false;
	private Vector3 originalPosition;
	public GameObject camera;
	private CameraController cameraController;

	// Use this for initialization
	void Start () {
		cameraController = GameObject.Find ("Main Camera").GetComponent<CameraController> ();
		originalPosition = currentPlatform.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (isMovingBack) {
			Vector3 backVector = originalPosition - currentPlatform.transform.position;
			backVector /= backVector.magnitude;
			backVector *= moveDirection.magnitude;
			currentPlatform.transform.Translate(backVector * Time.deltaTime);
			if (backVector.magnitude < 1) {
				isMovingBack = false;
				Debug.Log ("goback");
			}
		}*/
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.rigidbody != null) {
			//other.rigidbody.velocity.x = 0;
			//other.rigidbody.velocity.z = 0;

			if (goThroughFloor) {
				currentPlatform.SetActive(false);
			} else {
				changeGravity(other);
			}
			rotatePlayer();
			cameraController.antiGravityOn();
		}
	}

/*	void OnTriggerStay(Collider other) {
		if (goThroughFloor && other.gameObject != currentPlatform ) {
			currentPlatform.transform.Translate(moveDirection * Time.deltaTime);
		}
	}*/

	void OnTriggerExit(Collider other) {
		if (goThroughFloor && other.gameObject != currentPlatform) {
			//Debug.Log ("Exited");
			changeGravity (other);
			currentPlatform.SetActive(true);
			//isMovingBack = true;
		}
	}

	void changeGravity(Collider other) {
		other.gameObject.GetComponent<Gravity>().fallDirection = other.gameObject.GetComponent<Gravity>().fallDirection * -1;
	}
	void rotatePlayer(){
		player.transform.RotateAround (transform.position, transform.right, 180f);
	}
}