using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rBody; 
    private GroundSensor sensor;
    private BoxCollider2D boxCollider;
    public Animator anim;
    GameManager gameManager;
    public float playerSpeed = 5.5f;
    float horizontal;
    public float jumpForce = 3f;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        boxCollider = GetComponent<BoxCollider2D>(); 
        rBody = GetComponent<Rigidbody2D>();
        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if(gameManager.isGameOver == false)
        {
             horizontal = Input.GetAxis("Horizontal");
         if (horizontal < 0)
             {
                 transform.rotation = Quaternion.Euler(0, 180, 0);
                 anim.SetBool("IsRunning", true);
                } else if (horizontal > 0)
                 {
                      transform.rotation = Quaternion.Euler(0, 0, 0);
                      anim.SetBool("IsRunning", true);
                   } else{
                    anim.SetBool("IsRunning", false);
                   }
          if (Input.GetButtonDown("Jump") && sensor.isGrounded)
               {
                   rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                   anim.SetBool("IsJumping", true);
               }
        }

    }

    private void FixedUpdate() {
        rBody.velocity = new Vector2 (horizontal*playerSpeed, rBody.velocity.y);
    }

    public void PlayerDie()
    {
        boxCollider.enabled = false;
        Destroy(this.gameObject, 0.5f);
    }
}
