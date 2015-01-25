using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject toFollow;
	private Vector3 translationOffset;
	private bool isRotate = true;
	private Quaternion rotationOffset;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		translationOffset = new Vector3 (0.0f, 1.5f, -3f);
		rotationOffset = transform.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = toFollow.transform.position + translationOffset;
	}
	public void antiGravityOn (){
		translationOffset = -translationOffset;
	}
}
