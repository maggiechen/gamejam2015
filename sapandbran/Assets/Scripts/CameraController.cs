using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject toFollow;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = toFollow.transform.position + offset;
	}
}
