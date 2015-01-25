using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 1;

	public static int maxSpeedY = 20;

	public static int maxSpeed = 500;
	private int inputMultiplier = 450;
	private float jumpMagnitude = 150;
	private int friction = 3;
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
		float moveAxisX = inputMultiplier * Input.GetAxisRaw ("Horizontal");
		float moveAxisZ = inputMultiplier * Input.GetAxisRaw ("Vertical");

		if (moveAxisX == 0 && moveAxisZ == 0 && rigidbody.velocity != Vector3.zero) {
			rigidbody.drag = friction;
		}

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
		return new Vector3 (moveAxisX, 0.0f, 0.0f) + new Vector3 (0.0f, 0.0f, moveAxisZ);
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
	public void rotatePlayer(){
		transform.RotateAround (transform.position, transform.right, 180f);
	}
}
