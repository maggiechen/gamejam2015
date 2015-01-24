using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 1;

    public float jumpMagnitude = 100;
    private bool canJump;
	// Use this for initialization
	void Start () {
        canJump = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isOutsideGameBoundaries())
        {
            // TODO the death trigger or whatever here
            Debug.Log("The player is outside game boundaries");
        }
	}

	// called at fixed time intervals
	void FixedUpdate() {
		//Rigidbody rigidbody = new Rigidbody ();
		float moveHorizontal = 1000 * Input.GetAxis ("Horizontal");
        float moveVertical = 1000 * Input.GetAxis("Vertical");
        float jumpForce;

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

    bool isOutsideGameBoundaries()
    {
		Vector3 position = transform.position;
		int limit = 500;
		return !((position.x > -limit && position.x < limit) &&
			(position.y > -limit && position.y < limit) &&
			(position.z > -limit && position.z < limit));
	}
}
