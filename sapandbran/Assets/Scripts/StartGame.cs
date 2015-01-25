using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public void Update() {

		if (Input.GetKeyDown (KeyCode.Return)) {
			Application.LoadLevel ("LevelOne");
			
		}
	}
}
