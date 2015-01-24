using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 1;

    // TODO-BL Will change so we only change the jump magnitude in one place
    public float jumpMagnitude = 1000;
    private bool canJump;
	// Use this for initialization
	void Start () {
        canJump = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// called at fixed time intervals
	void FixedUpdate() {
		//Rigidbody rigidbody = new Rigidbody ();
		float moveAxisX = 1000 * Input.GetAxisRaw ("Horizontal");
        float moveAxisZ = 1000 * Input.GetAxisRaw("Vertical");
        float jumpForce = 0;
		Vector3 jumpMovement = new Vector3(0.0f, 0.0f, 0.0f);
        if (Input.GetKeyDown (KeyCode.Space) && canJump) {
			jumpForce = 100;
			canJump = false;
		}
		jumpMovement.Set(0.0f, jumpForce, 0.0f);
		Vector3 movement = VectorMovement (moveAxisX, moveAxisZ);
		rigidbody.AddForce (movement * speed * Time.deltaTime);
        rigidbody.AddForce (jumpMovement * jumpMagnitude * Time.deltaTime);
	}
	Vector3 VectorMovement(float moveAxisX, float moveAxisZ){
		Vector3 moveX = new Vector3 (moveAxisX, 0.0f, 0.0f);
		Vector3 moveZ = new Vector3 (0.0f, 0.0f, moveAxisZ);
		Vector3 test = moveX + moveZ;
		Debug.Log (test.x);
		return moveX + moveZ;

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
