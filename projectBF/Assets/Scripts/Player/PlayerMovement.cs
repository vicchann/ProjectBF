using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    private float moveInput;
    public float sprintSpeed;
    private float sprint;
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    private InputManager inputManager;

    void Start()
    {
        inputManager = GameObject.FindObjectOfType<InputManager>();
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (inputManager.GetButton("Sprint"))
        {
            sprint = sprintSpeed;
        }
        else
        {
            sprint = 1;
        }

        moveInput = 0;

        if (inputManager.GetButton("MoveLeft"))
        {
            moveInput = -1;
        }

         if (inputManager.GetButton("MoveRight"))
        {
            moveInput = 1;
        }

        rb.velocity = new Vector2(moveInput * moveSpeed * sprint, rb.velocity.y);

    }

    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (inputManager.GetButtonDown("Jump") && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;

        }
        else if (inputManager.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;

        }
    }
}

//        moveInput = Input.GetAxisRaw("Horizontal");