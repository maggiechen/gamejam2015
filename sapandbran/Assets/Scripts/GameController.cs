using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel ("MainMenu");
		}
	}

	public static void EndGame () {
		//TODO: show menu
		Application.LoadLevel (Application.loadedLevel);
	}

	public static void GameOver () {
		//TODO: show menu
		Application.LoadLevel ("MainMenu");
	}
}
