using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {
	public Vector3 fallDirection;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		rigidbody.AddForce (fallDirection);
	}
}
