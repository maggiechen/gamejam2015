using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 1;

    // TODO-BL Will change so we only change the jump magnitude in one place
    public float jumpMagnitude = 100;
    private bool canJump;
	// Use this for initialization
	void Start () {
        canJump = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// called at fixed time intervals
	void FixedUpdate() {
		//Rigidbody rigidbody = new Rigidbody ();
		float moveHorizontal = 10 * Input.GetAxis ("Horizontal");
        float moveVertical = 10 * Input.GetAxis("Vertical");
        float jumpForce;

        jumpForce = (Input.GetKeyDown(KeyCode.Space) && canJump) ? 100 : 0;
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            jumpForce = 100;
            canJump = false;
        }
        else
        {
            jumpForce = 0;
        }
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        Vector3 jumpMovement = new Vector3 (0.0f, jumpForce, 0.0f);

		rigidbody.AddForce (movement * speed * Time.deltaTime);
        rigidbody.AddForce (jumpMovement * jumpMagnitude * Time.deltaTime);
	}

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player collided with " + collision.gameObject.name);
        if (collision.gameObject.tag == "IsJumpable")
        {
            canJump = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Player stopped touching " + collision.gameObject.name);
        if (collision.gameObject.tag == "IsJumpable")
        {
            canJump = false;
        }
    }
}
