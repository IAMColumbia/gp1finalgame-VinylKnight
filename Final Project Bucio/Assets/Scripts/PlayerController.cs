using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float jumpForce;
    [SerializeField]
    private bool isOnGround;
    [SerializeField]
    private LayerMask defineGround;
   
    private float jumpTimeCounter;

    public float jumpTime;

    private Rigidbody2D playerRigidBody;
    private Collider2D playerCollider;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerAnimator = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics2D.IsTouchingLayers(playerCollider, defineGround);

        playerRigidBody.velocity = new Vector2(speed, playerRigidBody.velocity.y);
        UpdateJumpControl();
        playerAnimator.SetFloat("speed", playerRigidBody.velocity.x);

        playerAnimator.SetBool("Ground", isOnGround);
    }

    private void UpdateJumpControl()
    {
        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
        {
            if (isOnGround)
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if (jumpTimeCounter > 0)
            {
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
        }
        if (isOnGround)
        {
            jumpTimeCounter = jumpTime; 
        }
    }
}
