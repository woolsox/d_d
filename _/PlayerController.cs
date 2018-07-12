using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;             //Floating point variable to store the player's movement speed.
    public float jumpForce;         //Floating point variable to store the players jumping power.

    float moveInput;                //Either -1 or 0 to determine if the player pressed the L/R arrow keys.
    bool facingRight = true;        //Sets sprites inital appearance.

    bool isGrounded;                //Boolean to deteremine if the player is, or is not on the ground.
    public Transform groundCheck;   //Ground check element which binds to the player.
    public float checkRadius;       //Stores a reference to radius size value for the OverlapCirlce method. (Line::37)
    public LayerMask whatIsGround;  //Stores a reference to what LayerMask value is considered ground. ("Ground" in this case)

    Rigidbody2D rb;                 //Store a reference to the Rigidbody2D component required to use 2D Physics.

    int extraJumps;                 //Store a reference to how many extra jumps a player can have.
    public int extraJumpsValue;     //Public integer to assign the value of extraJumps during initalization.

    int coins = 0;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,
                                                         checkRadius,
                                                         whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0){
            Flip();
        } else if(facingRight == true && moveInput < 0) {
            Flip();
        }
    }

    void Update()
    {
        if(isGrounded == true) {
            extraJumps = 2;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0){
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true){
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pickup") {
            Destroy(collision.gameObject);
            coins++;
            Debug.Log(coins);
        }
    }
}