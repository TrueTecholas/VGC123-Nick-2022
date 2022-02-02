using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerControl : MonoBehaviour
{
    public float playerSpeed = 10;
    public float jumpForce = 7;
    private int jumpAmount = 3;
    private int jumpCount = 0;
    public bool isGrounded = false;
    public bool isAttacking = false;
    private int movementCancel = 1;

    private Vector3 initialScale;
    Animator anim;
    SpriteRenderer sr;

    void Start()
    {
       
        initialScale = transform.localScale;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // move character to right, deltaTime is the time between frame updates
            transform.position += playerSpeed * Vector3.right * Time.deltaTime * movementCancel;
            // flip character
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // move character to left, deltaTime is the time between frame 
            transform.position += playerSpeed * Vector3.left * Time.deltaTime * movementCancel;
            // change the scale back to intial so character faces the right direction
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < jumpAmount)
        {
            GetComponent<Rigidbody2D>().AddForce(jumpForce * Vector3.up, ForceMode2D.Impulse);
            jumpCount++;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < jumpAmount)
        {
            // Add vertical jump force
            GetComponent<Rigidbody2D>().AddForce(jumpForce * Vector3.up, ForceMode2D.Impulse);
            jumpCount++;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("Test For Attack");
            isAttacking = true;
            movementCancel = 0;
        }
        else
        {
            isAttacking = false;
            movementCancel = 1;
        }

       float hinput = Input.GetAxis("Horizontal");
        float vinput = Input.GetAxis("Vertical");
        anim.SetFloat("xVel", Mathf.Abs(hinput));
        anim.SetFloat("yVel", Mathf.Abs(vinput));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isAttacking", isAttacking);



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 8 is ground layer
        if (collision.gameObject.layer == 8)
        {
            isGrounded = true;
            jumpCount = 0;
        }
        // 10 is enemy layer
        if (collision.collider.gameObject.layer == 10 && !isGrounded)
        {
            Destroy(collision.rigidbody.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 8 is ground layer
        if (collision.gameObject.layer == 8)
        {
            isGrounded = false;
        }
    }
}
