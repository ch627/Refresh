using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float MoveSpeed = 5f; // determines the speed the player will moves at, by default, this is 5.
    public Rigidbody2D rb2d; // stores the Rigidbody 2D
    //public BoxCollider2D bc2d; // stores the BoxCollider 2D
    private float moveInput; // a float storing our move inputs, this is the A and D keys in our case.
    public bool facingRight = false; // is the player facing right? By default, they are facing left.
    private bool isGrounded; // is the player on the ground?
    public Transform groundCheck; // a refrence to an empty game object representing the transform of the ground.
    public float checkRadius; // the radius of the invisible circle checking if the player is on the ground.
    public LayerMask whatIsGround; // a refrence to the ground layer.
    private int extraJumps; // the amount of times the player can jump.
    public int extraJumpValue;
    public float jumpForce; // the force of the player's jump(s).
    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpValue;
        rb2d = GetComponent<Rigidbody2D>(); // get the player rigidbody
                                            // bc2d = GetComponent<BoxCollider2D>(); // get the pllayer collider
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded == true) // if the player is grounded...
        {
            extraJumps = extraJumpValue; // than reset extra jumps
        }
        /*Vector3 movment = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movment * Time.deltaTime * MoveSpeed;*/ //this is one way you could move your character if you're not too familar with unity or programming in general but if you have that familarity, there are many better options
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0) // if the player presses the space key and has jumps left...
        {
            rb2d.velocity = Vector2.up * jumpForce; // then the player can jump
            extraJumps--; // each time the player jumps, they lose a jump.
        }else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true) // if the player trys to jump but has no extra jumps, although they are on the ground....
        {
            rb2d.velocity = Vector2.up * jumpForce; // the player can still jump
        }

      


    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround); // create an invisible circle checking if the player is on the ground
        moveInput = Input.GetAxis("Horizontal"); // set the move keys equal to A and D
        Debug.Log(moveInput); // print the number of move inputs to the console, if these are greater than 0, we should be moving the player.
        rb2d.velocity = new Vector2(moveInput * MoveSpeed, rb2d.velocity.y); // move the player if the press A or D.

        if (facingRight == false && moveInput > 0) // if the player is facing left and they're not moving...
        {
            Flip(); // flip the player to face left
        }
        else if (facingRight == true && moveInput < 0)  // if the player is facing right and moving to the right...
        {
            Flip(); // flip them to face right.
        }
    }

    void Flip() // flip the player depending on which direction they're facing.
    {
        facingRight = !facingRight; // if the player was facing right, now they're facing left and vise versa.
        /*Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;*/
        transform.Rotate(0, 180, 0); // rotating the player 180 degrees to flip him made my life a lot easier than using the player's x scale to do so.
    }
    }

