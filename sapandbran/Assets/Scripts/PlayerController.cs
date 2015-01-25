using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 1;

	public static int maxSpeedY = 20;

    // TODO-BL Will change so we only change the jump magnitude in one place
    public float jumpMagnitude = 1000;
    private float distToGround;
	private bool isAntiGravityOn = false;
	// Use this for initialization
	void Start () {
        distToGround = collider.bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(rigidbody.velocity.y) > maxSpeedY) {
			GameController.GameOver ();
		}
	}

	// called at fixed time intervals
	void FixedUpdate() {
		//Rigidbody rigidbody = new Rigidbody ();
		float moveAxisX = 1000 * Input.GetAxisRaw ("Horizontal");
        float moveAxisZ = 1000 * Input.GetAxisRaw ("Vertical");
        float jumpForce = 0;
		Vector3 jumpMovement = new Vector3(0.0f, 0.0f, 0.0f);
        if (Input.GetKeyDown(KeyCode.Space) && IsTouchingGround())
        {
			if (isAntiGravityOn){
				jumpForce = -100f;
			}else{
				jumpForce = 100;
			}
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
	public void antiGravityOn(){
		if (isAntiGravityOn) 
			isAntiGravityOn = false;
		else
			isAntiGravityOn = true;
	}
    bool IsTouchingGround()
    {
		Vector3 down;
		if (isAntiGravityOn)
			down = Vector3.up;
		else
			down = Vector3.down;
        return (Physics.Raycast(transform.position, down, distToGround)) ? true : false;
    }
}
