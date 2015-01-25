using UnityEngine;
using System.Collections;

public class TutorialTextController : MonoBehaviour {

    public GUIText tutorialText;

	// Update is called once per frame
	void Update () {
        Vector2 offset = new Vector2(Screen.width / 2, Screen.height - 50);
        tutorialText.pixelOffset = offset;
	}
}
