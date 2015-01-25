using UnityEngine;
using System.Collections;

public class Hover : MonoBehaviour {
	float index = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		index += 0.1f;
		gameObject.transform.Translate (new Vector3 (0f, Mathf.Sin (index) / 200, 0f));
	}
}
