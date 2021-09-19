using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController2d : MonoBehaviour
{

    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        this.PlayerAnimator = GetComponent<Animator>();
    }

    public void SetDirection(float horizontalMoveValue)
    {
        this.PlayerAnimator.SetFloat("Direction", horizontalMoveValue);
    }

    public void SetCrouchingState(bool isCrouching)
    {
        this.PlayerAnimator.SetBool("IsCrouching", isCrouching);
    }

    public void SetJumpingState(bool isJumping)
    {
        this.PlayerAnimator.SetBool("IsJumping", isJumping);
    }

    public Animator PlayerAnimator { get => playerAnimator; set => playerAnimator = value; }
}
