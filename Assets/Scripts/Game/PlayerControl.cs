using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float jumpSpeed1;
    public float jumpSpeed2;

    public GameWindow gameWindow;
    
    private int jumpCount = 2;
    private Vector3 playerScale;
    private Rigidbody2D playerRigidbody2D;
    private CapsuleCollider2D playerFeet;
    private Animator playerAni;
    public void InitPlayer()
    {
        playerScale = transform.localScale;
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerFeet = GetComponent<CapsuleCollider2D>();
        playerAni = GetComponent<Animator>();
    }

    private void Update()
    {
        Run();
        Jump();
        Fall();
        IfOnGround();
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = playerScale;
            playerRigidbody2D.velocity = new Vector2(speed,playerRigidbody2D.velocity.y);
            playerAni.SetBool("ifRun", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-playerScale.x,playerScale.y,playerScale.z);
            playerRigidbody2D.velocity = new Vector2(- speed,playerRigidbody2D.velocity.y);
            playerAni.SetBool("ifRun", true);
        }
        else
        {
            playerRigidbody2D.velocity = new Vector2(0,playerRigidbody2D.velocity.y);
            playerAni.SetBool("ifRun", false);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && jumpCount != 0)
        {
            playerAni.SetBool("ifJump", true);
            playerAni.SetBool("ifFall", false);
            playerAni.SetBool("ifIdle", false);
            if (jumpCount == 2)
            {
                playerRigidbody2D.velocity = Vector2.up * jumpSpeed1;
            }
            else if (jumpCount == 1)
            {
                playerRigidbody2D.velocity = Vector2.up * jumpSpeed2;
                jumpCount--;
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (playerRigidbody2D.velocity.y > 3f)
            {
                playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x,3f);
            }
                
        }
    }

    private void Fall()
    {
        if (playerRigidbody2D.velocity.y < 0f)
        {
            playerAni.SetBool("ifFall", true); 
            playerAni.SetBool("ifJump", false);
            playerAni.SetBool("ifIdle", false);
        }

        if (playerRigidbody2D.velocity.y < -8f)
        {
            playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x,-8f);
        }
    }
    private void IfOnGround()
    {
        if (playerFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            jumpCount = 2;
            if (playerAni.GetBool("ifFall"))
            { 
                playerAni.SetBool("ifFall", false);
                playerAni.SetBool("ifIdle", true);
            }
        }
        else
        {
            if (jumpCount == 2)
            {
                jumpCount--;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Spike"))
        {
            gameWindow.GameOver();
        }
        else if (collision.transform.CompareTag("NextLevelSign"))
        {
            gameWindow.NextLevel();
        }
    }
}
