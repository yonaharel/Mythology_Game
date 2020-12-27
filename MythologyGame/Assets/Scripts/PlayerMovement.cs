using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float runSpeed = 50f;
    public Animator animator;
    public Joystick joystick;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    public CharacterController2D controller;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Input
        horizontalMove = joystick.Horizontal * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        float verticalMove = joystick.Vertical;

        //if (verticalMove <= .5f)
        //{
        //    crouch = true;
        //}
        //else crouch = false;

    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void JumpButtonPressed()
    {
        jump = true;
        animator.SetBool("isJumping", true);
    }

    public void CrouchButtonPressed()
    {
        crouch = true;
        
    }

    private void FixedUpdate()
    {
        animator.SetBool("isCrouching", crouch);
        //Movement
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        crouch = false;
    }
}
