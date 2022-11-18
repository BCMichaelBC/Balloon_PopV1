using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float movement;
    [SerializeField] int speed = 15;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 500.0f;
    [SerializeField] bool isGrounded = true;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Animator animator;

    const int IDLE = 0;
    const int RUN = 1;
    const int JUMP = 2;
    const int SHOOT = 3;



    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();

        if (animator == null)
            animator = GetComponent<Animator>();


            animator.SetInteger("Motion", IDLE);

            speed = 15;
    }

    // Update is called once per frame
    // usuually used for User Input
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        // to jump
        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;

        if (!jumpPressed && isGrounded)
        {
            if (movement >= .01 || movement <= -.01)
                animator.SetInteger("Motion", RUN);
            else
                animator.SetInteger("Motion", IDLE);
        }



        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
        if (movement < 0 && isFacingRight || movement > 0 &&!isFacingRight)
            Flip();
        
        if (jumpPressed && isGrounded)
            Jump();

    }


    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    void Jump()
    {
        animator.SetInteger("Motion", JUMP);
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        // its like (x, y) when u press to jump we arent moving horizonlty but vertically
        rigid.AddForce(new Vector2(0, jumpForce));
        isGrounded = false; // not on ground any more 
        jumpPressed = false; // to avoid double jump
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true; // youve hit the ground again
            animator.SetInteger("Motion", IDLE);
        }
    }

    void Shoot()
    {
        animator.SetInteger("Motion", SHOOT);
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

    }
}
