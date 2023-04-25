using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class playerController : MonoBehaviour {

    [Header("Movement")]
    [SerializeField] Rigidbody2D rb;

    [SerializeField] float jumpForce = 2f;

    bool isGrounded;
    bool isCrouching;

    [SerializeField] Vector2 standingSize;
    [SerializeField] Vector2 crouchingSize;

    Vector2 scale;

    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask whatIsGround;

    // [SerializeField] Vector2 crouchSize;

    void Start() {
        scale = transform.localScale;
    }

    void Update() {
      
    }

    void FixedUpdate() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    public void Jump(InputAction.CallbackContext context) {
        if(isGrounded) {
            // animator.SetTrigger("jump");
            FindObjectOfType<AudioManager>().Play("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public void Crouch(InputAction.CallbackContext context) {
        if(context.started) {
            scale.y = crouchingSize.y; // your new value
            transform.localScale = scale;
        } else if(context.canceled) {
            scale.y = standingSize.y; // your new value
            transform.localScale = scale;
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }

}
