using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;
    private bool facingRight = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Input
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");
       animator.SetFloat("Horizontal", movement.y);
       animator.SetFloat("Vertical", movement.x);
       animator.SetFloat("Speed", movement.sqrMagnitude);

        Vector3 localScale = transform.localScale;

        if (movement.x < 0 && facingRight)
        {
            facingRight = false;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
        
        if (!facingRight && movement.x > 0)
        {
            facingRight = true;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    private void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
