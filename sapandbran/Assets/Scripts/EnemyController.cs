using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public float offsetX;
	public float offsetY;
	public float offsetZ;
//	public Vector3 pointB;


	// Use this for initialization
	IEnumerator Start () {
		gameObject.renderer.material.color = Color.red;
		Vector3 pointA = transform.position;
		Vector3 pointB = pointA + new Vector3 (offsetX, offsetY, offsetZ);
		while (true) {
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
		}
	}

	IEnumerator MoveObject (Transform thisTransform, Vector3 startPos, Vector3 endPos, float time) {
		float i = 0.0f;
		float rate = 1.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			GameController.EndGame();
		}
	}
}



