using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jump;
    public KeyCode JumpKey;
    private Rigidbody2D rb;
    private bool isGrounded;
    private GameManager gameManager;
    public bool isPlayer1 = true;
    public bool isPlayer2 = false;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the jump key is held down for a short jump
        /*if (Input.GetKeyDown(JumpKey) && isGrounded)
        {
            rb.AddForce(Vector2.up * shortJump, ForceMode2D.Impulse);
            hasJumped = false;
        }*/
        if (Input.GetKeyDown(JumpKey) && isGrounded)
        {
            rb.AddForce(Vector2.up * jump);
        }

        if (Input.GetKeyUp(JumpKey))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
       if (other.gameObject.tag == "Enemy")
        {
            if (isPlayer1)
            {
                gameManager.SetPlayer1Destroyed(true);
            }
            else
            {
                gameManager.SetPlayer2Destroyed(true);
            }
            
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
