using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			GameController.EndGame();
		}
	}
}
