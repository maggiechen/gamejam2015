using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

    public GUIText navigationText;
    private float xPixelOffset = -Screen.width/2 + 150;
    private float yPixelOffset = -Screen.height/2 + 60;

    public GameObject tutorialObjects;
    public int numTutorialObjects;
    private int tutorialObjectsViewed = 0;

    public float smoothTime = 0.3F;
    private Vector3 targetPosition;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        Vector3 targetPosition = Camera.main.transform.position;
    }

	public void Update() {

		if (Input.GetKeyDown (KeyCode.Return)) {
			Application.LoadLevel ("LevelOne");
			
		}

		if (Input.GetKeyDown (KeyCode.Space))
		{
			if (tutorialObjectsViewed < numTutorialObjects)
			{
			    navigationText.text = "Press SPACEBAR to continue the tutorial\n\nPress ENTER to play";
			    navigationText.pixelOffset = new Vector2(xPixelOffset, yPixelOffset);
			    navigationText.alignment = TextAlignment.Left;
			    targetPosition = tutorialObjects.transform.position;
			    targetPosition.x -= 50;
			    tutorialObjectsViewed++;
			}
            else
            {
                navigationText.text = "Press ENTER to play";
                navigationText.pixelOffset = new Vector2(0, 0);
                navigationText.alignment = TextAlignment.Center;
                tutorialObjects.SetActive(false);
            }
		}

        tutorialObjects.transform.position = Vector3.SmoothDamp(tutorialObjects.transform.position, targetPosition, ref velocity, smoothTime);

	}
}
