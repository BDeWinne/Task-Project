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
    private bool isMoving;
    private Animator playerAnim;
    private SpriteRenderer spriteRenderer;
    private float hMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        UI_Controller.Instance.movEvt.AddListener(CheckMovement);

        UI_Controller.Instance.jumpEvt.AddListener(Jump);
    }

    void Update()
    {
        if(isMoving){
            Movement(hMovement);
        }
    }

    private void CheckMovement(float moveHorizontal){
        if(moveHorizontal != 0){
            hMovement = moveHorizontal;
            isMoving = true;
        }
        else{
            playerAnim.SetBool("isMoving", false);
            isMoving = false;
        }
        CheckDirection(moveHorizontal);
    }

    private void CheckDirection(float hMovement){
        if(hMovement> 0){
            spriteRenderer.flipX = false;
        }
        else if(hMovement<0){
            spriteRenderer.flipX = true;
        }
    }

    private void Movement(float hMovement){
        playerAnim.SetBool("isMoving", true);
        Vector2 movement = new Vector2(hMovement, 0f) * speed;
        rb.velocity = new Vector2(movement.x, rb.velocity.y);        
    }

    private void Jump(){
        if (isGrounded)
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
