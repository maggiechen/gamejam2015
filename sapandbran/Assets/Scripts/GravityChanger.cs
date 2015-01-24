using UnityEngine;
using System.Collections;

public class GravityChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.rigidbody != null) {
			//do stuff here
		}
	}

}