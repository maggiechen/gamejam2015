using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private float speed = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// called at fixed time intervals
	void FixedUpdate() {
		//Rigidbody rigidbody = new Rigidbody ();
		float moveHorizontal = 10 * Input.GetAxis ("Horizontal");
		float moveVertical = 10 * Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}
}
