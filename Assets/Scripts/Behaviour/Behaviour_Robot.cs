using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour_Robot : MonoBehaviour {

	bool collisionLever = false;

	private Transform RobotMovement = null;

	public float Speed = 10.0f;

	// Useful for the sprite direction
	public enum FACEDIRECTION { FACELEFT = -1, FACERIGHT = 1 };

	public FACEDIRECTION Facing = FACEDIRECTION.FACERIGHT;

	public bool isGrounded = false;
	public bool stop = false;


	// Penser a mettre le circle collider 2d dans les jambes du robot
	public CircleCollider2D FeetCollider = null;


	private Rigidbody2D ydaBody = null;
	public bool CanJump = true;

	public LayerMask GroundLayer;

	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;
	bool onceJump = false;

	private Animator ThisAnimator = null;
	private int MotionVal = Animator.StringToHash("Motion");

	// Use this for initialization
	void Awake()
	{
		RobotMovement = GetComponent<Transform>();

		// Get Animator
		ThisAnimator = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
		ydaBody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		if (!collisionLever && !stop)
		{
			//Update object position
			moveYDA();
			ThisAnimator.SetFloat(MotionVal, 1, 0.1f, Time.deltaTime);
		}
		if (collisionLever || onceJump || stop)
		{
			ThisAnimator.SetFloat(MotionVal, 0, 0.1f, Time.deltaTime);
		}
		//	isGrounded = GetGrounded();	
		jump(isGrounded,onceJump);

		// Flip direction if required
		// Moving left => flip -----------------------------------Moving Right => flip ---------
		/*if ((Horz < 0f && Facing != FACEDIRECTION.FACELEFT) || (Horz > 0f && Facing != FACEDIRECTION.FACERIGHT))
		{
			FlipDirection();
		}*/


	}


	/* -------------------------------------- */
	// Returns bool - is yda on ground ?
	/*private bool GetGrounded()
	{
		// check Ground
		Vector2 CircleCenter = new Vector2(RobotMovement.position.x, RobotMovement.position.y) + FeetCollider.offset;
		Collider2D[] HitColliders = Physics2D.OverlapCircleAll(CircleCenter, FeetCollider.radius, GroundLayer);
		if (HitColliders.Length > 0)
		{
			return true;
		}
		return false;
	}
	*/

	/* -------------------------------------- */
	//Engage Jump
	/*	private void Jump()
		{
			// if we are grounded, then jump
			if (!isGrounded || !CanJump) return;

			//Jump
			ydaBody.AddForce(Vector2.up * JumpSpeed);
			CanJump = false;
		}
		*/

	
	/* -------------------------------------- */
	// Activates can jump variable after jump timeout
	// prevents double jumps
	private void ActivateJump()
	{
		CanJump = true;
	}


	/* -------------------------------------- */
	// Flips the character direction
/*	private void FlipDirection()
	{
		Facing = (FACEDIRECTION)((int)Facing * -1f);
		Vector3 LocalScale = RobotMovement.localScale;
		LocalScale.x *= -1f;
		RobotMovement.localScale = LocalScale;
	}
*/

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.name == "ControlLever")
		{	
			stop=true;
			collisionLever = true;
			Debug.Log("Collision avec levier !" + collisionLever);
		}
		if (collision.gameObject.tag == "GroundLayer")
		{	
			isGrounded=true;
			Debug.Log("Grounded :(");
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "GroundLayer")
		{	isGrounded= false;
			Debug.Log("sauter !!");
		}
	}

	public Vector3 moveYDA()
	{
		RobotMovement.position += RobotMovement.right * Speed * Time.deltaTime;
		return RobotMovement.position;
	}
	public void jump(bool sol,bool saut){
		if (!stop){
			if (!sol && !saut)
			{
				
				Debug.Log("Saute");
				RobotMovement.position += RobotMovement.up * 4 * Time.deltaTime;
				/*moveDirection = Vector3.zero;
				moveDirection.x = 1;
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= Speed;
				onceJump = true;*/
			}
			else if (sol)
			{
			//	moveDirection.y = jumpSpeed;
				onceJump = false;
			}
			float temp = gravity * Time.deltaTime;
			RobotMovement.position.Set(RobotMovement.position.x,temp,RobotMovement.position.z);

		}
	}
}

