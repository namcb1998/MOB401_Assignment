using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float jumpForceAbs;
	private float jumpForce;
	private float freshJumpForce;
	private Rigidbody2D _rigidbody2D;

	private bool isGround;
	private bool isFreshJump;
	private bool canJump;

	private Animator _animator;
	
	// Use this for initialization
	void Start ()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		freshJumpForce = jumpForceAbs * 5f;
		canJump = false;
		jumpForce = jumpForceAbs;
		_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate()
	{
		Jump();
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		isGround = true;
		Debug.Log("OnTriggerEnter2D");
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		isGround = true;
		Debug.Log("OnTriggerStay2D");
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		isGround = false;
		Debug.Log("OnTriggerExit2D");
		_animator.SetBool("isRunning",false);
	}

	private void Jump()
	{
		if (Input.GetKey(KeyCode.Space)&&isFreshJump)
		{
			Debug.Log("fresh");
			_rigidbody2D.AddForce(Vector2.up*freshJumpForce,ForceMode2D.Force);
			isFreshJump = false;
		}else if (Input.GetKey(KeyCode.Space)&&canJump)
		{
			_rigidbody2D.AddForce(Vector2.up*jumpForce,ForceMode2D.Force);
		}

		if (Input.GetKeyUp(KeyCode.Space)&&!isGround)
		{
			canJump = false;
		}
		



		if (!isGround)
		{
			jumpForce -= 2f;
			if (jumpForce<0)
			{
				jumpForce = 0;
			}
		}

		if (isGround)
		{
			_animator.SetBool("isRunning",true);
			isFreshJump = true;
			jumpForce = jumpForceAbs;
			canJump = true;
		}
	}
	//link oc cho
}
