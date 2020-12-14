using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    private float speedMultiplier;
    [SerializeField]
    private float speedIncreaseMilestone;
   
    [SerializeField]
    float jumpForce;
    [SerializeField]
    private bool isOnGround;
    [SerializeField]
    private LayerMask defineGround;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundCheckRadius;
    [SerializeField]
    private GameplayManager theGameplayManager;
   
    private float jumpTimeCounter;
    private float speedMilestoneCount;
    private float speedMilestoneCountStore;
    private float speedStore;
    private float speedIncreaseMilestoneStore;
    
    public float jumpTime;

    private bool hasStoppedJumping;

    private Rigidbody2D playerRigidBody;
    //private Collider2D playerCollider;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        //playerCollider = GetComponent<Collider2D>();
        playerAnimator = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
        speedStore = speed;
        speedMilestoneCount = speedIncreaseMilestone;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
        hasStoppedJumping = true;
    }

    // Update is called once per frame
    void Update()
    {
        //isOnGround = Physics2D.IsTouchingLayers(playerCollider, defineGround);
        isOnGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, defineGround);

        UpdateJumpControl();
        
        playerRigidBody.velocity = new Vector2(speed, playerRigidBody.velocity.y);
        
        UpdateSpeedMultiplier();
        
        playerAnimator.SetFloat("speed", playerRigidBody.velocity.x);
        playerAnimator.SetBool("Ground", isOnGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "killbox")
        {
            theGameplayManager.RestartGame();
            speed = speedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
        }
    }

    private void UpdateSpeedMultiplier()
    {
        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            speed = speed * speedMultiplier;
        }
    }

    private void UpdateJumpControl()
    {
        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
        {
            if (isOnGround)
            {
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
                hasStoppedJumping = false;
            }
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) && !hasStoppedJumping)
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
            hasStoppedJumping = true;
        }
        if (isOnGround)
        {
            jumpTimeCounter = jumpTime; 
        }
    }
}
