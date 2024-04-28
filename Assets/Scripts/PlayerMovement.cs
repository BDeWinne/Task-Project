using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] float speed; 
    [SerializeField] float jumpForce; 
    private Rigidbody2D rb; 
    private bool isGrounded; 
    private Animator playerAnim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckMovement();
    }

    private void CheckMovement(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        if(moveHorizontal != 0){
            Movement(moveHorizontal);
        }
        else{
            playerAnim.SetBool("isMoving", false);
        }
    }

    private void Movement(float hMovement){
        playerAnim.SetBool("isMoving", true);
        Vector2 movement = new Vector2(hMovement, 0f) * speed;
        rb.velocity = new Vector2(movement.x, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            playerAnim.SetBool("isGrounded", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            playerAnim.SetBool("isGrounded", true);
        }
    }
}
