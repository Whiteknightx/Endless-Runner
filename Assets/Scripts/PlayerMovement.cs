using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float tiltangle = 30f;
    public float gravity;
    public Vector2 velocity;
    public float jumpVelocity = 20;
    public float groundHeight = 10;
    public bool isGrounded = false;

    public bool isHoldingJump = false;
    public float maxHoldJumpTime = 0.4f;
    public float holdJumpTimer = 0.0f;

    public float jumpGroundThreshold = 1;
    string horizontalAxisName = "Horizontal";
    float horizontalInput;

    Vector3 moveVector;

    GameObject GFX;

    public static Animator anim;

    void Start()
    {
        GFX = transform.GetChild(0).gameObject;
        anim = transform.GetComponent<Animator>();
    }

    void Move()
    {
        horizontalInput = Input.GetAxis(horizontalAxisName);
        moveVector = new Vector3(-horizontalInput * speed, 0f, 0f);

        if (horizontalInput == 0f) // no input
        {
            // Calculate rotation angle towards 0 degrees
            float targetAngle = Mathf.LerpAngle(GFX.transform.rotation.eulerAngles.y, 0f, Time.deltaTime * 0.1f);
            GFX.transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        }
        else
        {
            // Calculate rotation angle based on moveVector
            float rotationAngle = horizontalInput * tiltangle;

            // Smoothly rotate towards the calculated angle
            GFX.transform.rotation = Quaternion.Lerp(GFX.transform.rotation, Quaternion.Euler(0f, rotationAngle, 0f), tiltangle * Time.deltaTime);
        }

        transform.position -= moveVector * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        
    }



    void Jump()
    {
        velocity.x = moveVector.z;

        Vector2 pos = transform.position;
        float groundDistance = Mathf.Abs(pos.y - groundHeight);

        if (isGrounded || groundDistance <= jumpGroundThreshold)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                anim.SetBool("Jump", true);
                isGrounded = false;
                velocity.y = jumpVelocity;
                isHoldingJump = true;
                holdJumpTimer = 0;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            isHoldingJump = false;
        }
    }

    private void FixedUpdate()
    {
        GroundCheck();
    }

    void GroundCheck()
    {
        Vector3 pos = transform.position;

        if (!isGrounded)
        {
            if (isHoldingJump)
            {
                holdJumpTimer += Time.fixedDeltaTime;
                if (holdJumpTimer >= maxHoldJumpTime)
                {
                    isHoldingJump = false;
                }
            }


            pos.y += velocity.y * Time.fixedDeltaTime;
            if (!isHoldingJump)
            {
                velocity.y += gravity * Time.fixedDeltaTime;
            }

            if (pos.y <= groundHeight)
            {
                anim.SetBool("Jump", false);
                pos.y = groundHeight;
                isGrounded = true;
            }
        }

        transform.position = pos;
    }
}