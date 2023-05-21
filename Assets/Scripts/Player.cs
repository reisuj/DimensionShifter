using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    private bool isJumping = false;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Move character horizontally
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        // Jump if the Jump button is pressed
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reset isJumping flag when landing on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    public void TogglePhasing()
    {
        // Get the Collider2D component attached to the object
        Collider2D objectCollider = GetComponent<Collider2D>();

        // Toggle the collider on or off
        objectCollider.enabled = !objectCollider.enabled;

        // Get the Rigidbody2D component attached to the object
        Rigidbody2D objectRigidbody = GetComponent<Rigidbody2D>();

        // Toggle the gravity on or off
        objectRigidbody.isKinematic = !objectRigidbody.isKinematic;
    }
}
