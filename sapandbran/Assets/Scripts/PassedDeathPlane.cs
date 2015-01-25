using UnityEngine;
using System.Collections;

public class PassedDeathPlane : MonoBehaviour {
	public GameObject player;

	public GUIText deathText;

	
	void FixedUpdate () {
		float playerYPosition = player.transform.position.y;
		float playerAdjustment = player.renderer.bounds.size.y; // This accounts for the size of the character in bounds
		float playerY = playerYPosition - playerAdjustment;

		float deathPlaneY = this.transform.position.y;
		if (playerY < deathPlaneY) {
			deathText.text = "You have fallen off the earth!";
		}
	
	}
}
