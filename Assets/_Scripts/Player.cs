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

    private float lastTimePressedSpace;
    [SerializeField] private AudioClip[] _audioClips;
    // 0 jump , 1 superhero landing , 3 coin

    // Use this for initialization
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        freshJumpForce = jumpForceAbs * 4.7f;
        canJump = false;
        jumpForce = jumpForceAbs;
        _animator = GetComponent<Animator>();
        lastTimePressedSpace = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void FixedUpdate()
    {
        Jump();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            isGround = true;
           // GetComponent<AudioSource>().PlayOneShot(_audioClips[1]);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            isGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            isGround = false;
            _animator.SetBool("isRunning", false);
        }
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space)&&isFreshJump)
        {
            
        }
        if (Input.GetKey(KeyCode.Space) && isFreshJump)
        {
            if (lastTimePressedSpace<Time.time-0.3f)
            {
                isFreshJump = false;
                lastTimePressedSpace = Time.time;
                GetComponent<AudioSource>().PlayOneShot(_audioClips[0]);
                _rigidbody2D.AddForce(Vector2.up * freshJumpForce*4, ForceMode2D.Force);

            }
            

        }
        else if (Input.GetKey(KeyCode.Space) && canJump)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
        }

        if (Input.GetKeyUp(KeyCode.Space) && !isGround)
        {
            canJump = false;
        }


        if (!isGround)
        {
            jumpForce -= 2f;
            if (jumpForce < 0)
            {
                jumpForce = 0;
            }
        }

        if (isGround)
        {
            _animator.SetBool("isRunning", true);
            isFreshJump = true;
            jumpForce = jumpForceAbs;
            canJump = true;
        }
    }
    
    //link oc cho
}