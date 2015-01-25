using UnityEngine;
using System.Collections;

public class KeyPress : MonoBehaviour {

	public void Update() {
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel (Application.loadedLevel);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel ("MainMenu");

		}
	}
}
