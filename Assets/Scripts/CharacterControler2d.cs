using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler2d : MonoBehaviour
{
    private const float MOVE_SPPED = 30f;
    private const float JUMP_SPPED = 70f;
    private Rigidbody2D rigidBody2D;
    private Vector3 moveDirection;
    private AnimationController2d animationController2D;
    private bool isJumping = false;
    private CircleCollider2D circleCollider2D;
    [SerializeField] 
    private LayerMask layerMask;
    [SerializeField]
    private CameraController cameraController;
    // Start is called before the first frame update
    void Start()
    {
        this.animationController2D = GetComponent<AnimationController2d>();
        this.rigidBody2D = GetComponent<Rigidbody2D>();
        this.circleCollider2D = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {

        float movementOnX = 0f;
        bool isCrouching = false;

        bool isGrounded = IsGrounded();

        if (Input.GetKey(KeyCode.DownArrow))
        {
            isCrouching = true;
        }

        if (Input.GetKey(KeyCode.RightArrow) && !isCrouching)
        {
            movementOnX = 1f;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && !isCrouching)
        {
            movementOnX = -1f;
        }

        if (isGrounded)
        {
            this.isJumping = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isCrouching && isGrounded)
        {
            this.isJumping = true;
            this.rigidBody2D.velocity = Vector2.up * JUMP_SPPED;
        }

        this.moveDirection = new Vector3(movementOnX * MOVE_SPPED, this.rigidBody2D.velocity.y);
        this.rigidBody2D.velocity = moveDirection;
        animationController2D.SetDirection(movementOnX);
        animationController2D.SetCrouchingState(isCrouching);
        animationController2D.SetJumpingState(isJumping && !isGrounded);
        this.cameraController.SetUp(() => this.transform.position);
    }


    private void FixedUpdate()
    {
       
    }


    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(this.circleCollider2D.bounds.center, this.circleCollider2D.bounds.size, 0, Vector2.down, 0.1f, this.layerMask);
        return raycastHit2D.collider != null;
    }
}
