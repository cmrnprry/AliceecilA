using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    [HideInInspector] public bool facingRight = true;

    //how fast the player moves
    public float maxSpeed;

    //how high the player jumps
    public float jumpForce;

    //Check if grounded
    public LayerMask groundLayer;
    private float distance = 1f;

    //if the player presses left or right
    private float moveInput;

    //Start pos for the player
    private Vector3 startPos;

    private Rigidbody2D rb2d;

    private Animator anim;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        startPos = this.gameObject.transform.position;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Jump", false);

        if (Input.GetKeyDown("space"))
        {
            Jump();
        }
    }

    //jump function
    void Jump()
    {
        if (isGrounded())
        {
            anim.SetBool("Jump", true);
            rb2d.AddForce(new Vector2(0f, jumpForce));
        }
    }

    //Check to see if player is grounded
    bool isGrounded()
    {
        Vector2 pos = this.transform.position;
        Vector2 dir;

        //fixes raycasting for when gravity changes
        if (jumpForce < 0)
        {
            dir = Vector2.up;
        }
        else
        {
            dir = Vector2.down;
        }

        //Debug.DrawRay(pos, dir, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(pos, dir, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    void FixedUpdate()
    {
        anim.SetFloat("Walk", false);

        moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput > 0 || moveInput < 0)
        {
            rb2d.velocity = new Vector2(moveInput * maxSpeed, rb2d.velocity.y);
            anim.SetFloat("Walk", true);
        }
        else
        {
            rb2d.velocity = new Vector2(moveInput, rb2d.velocity.y);
        }



        if (moveInput > 0 && !facingRight || moveInput < 0 && facingRight)
        {
            Flip();
        }
    }

    //flips the player's sprite
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void ResetPlayer()
    {
        //resets position
        this.gameObject.transform.position = startPos;

        //Resets gravity to normal
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;

        //Flips player to normal
        Vector3 rotate = this.transform.localEulerAngles;
        rotate.z = 0;
        this.transform.localEulerAngles = rotate;

        //Returns jump to normal
        jumpForce = 275f;

        //Returns speed to normal
        maxSpeed = 5f;
    }
}