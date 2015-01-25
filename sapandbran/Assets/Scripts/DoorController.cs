using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Debug.Log("Collide with player");
			GameController.EndGame();
		}
	}
}
