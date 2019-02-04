using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public Transform groundCheck;
    private float moveInput;        //this store the input value
    public float jumpHeight;


    private bool grounded = false;
    private Rigidbody2D rb2d;



    // Use this for initialization
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            grounded = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && grounded)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            grounded = false;

        }
    }

    void FixedUpdate()
    {
        //the moveInput will be 1 when we press right key and -1 for left key
        moveInput = Input.GetAxis("Horizontal");

        if (moveInput > 0)
        {
            rb2d.velocity = new Vector2(moveInput * maxSpeed, rb2d.velocity.y);
        }
        else if (moveInput < 0)
        {
            //here we set our player x velocity and y will not ne changed
            rb2d.velocity = new Vector2(moveInput * maxSpeed, rb2d.velocity.y);

        }

        if (moveInput > 0 && !facingRight)
            Flip();
        else if (moveInput < 0 && facingRight)
            Flip();

        if (jump)
        {

            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}