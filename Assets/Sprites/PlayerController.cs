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
    SoundManager soundManager;
    SFXManager sfxManager;
    public float playerSpeed = 5.5f;
    float horizontal;
    public float jumpForce = 3f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public Transform attackHitBox;
    public float attackRange;
    public LayerMask enemyLayer;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        boxCollider = GetComponent<BoxCollider2D>(); 
        rBody = GetComponent<Rigidbody2D>();
        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
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
                   sfxManager.PlayerJump();
               }
        }

        //Disparo
         if(Input.GetKeyDown(KeyCode.K) && gameManager.canShoot)
        {
            anim.SetBool("IsShoot", true);
            Invoke("Shooting", 0.3f);
            sfxManager.PlayerShoot();
            gameManager.powerUpTimer = 0;
        }else
            {
                anim.SetBool("IsShoot", false);
             }
        
        //Melee
        if(Input.GetKeyDown(KeyCode.J) && gameManager.plMelee)
        {
            Attack();
            anim.SetBool("IsMelee", true);
            sfxManager.PlayerMelee();
            gameManager.meleeTimer = 0;
        }else
        {
            anim.SetBool("IsMelee", false);
        }

    }

    void Shooting()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }

    void Attack()
    {
         Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attackHitBox.position, attackRange, enemyLayer);

         for(int i = 0; i < enemiesInRange.Length; i++)
         {
            Destroy(enemiesInRange[i].gameObject);
         }
    }

    void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(attackHitBox.position, attackRange);    
    }

    private void FixedUpdate() {
        rBody.velocity = new Vector2 (horizontal*playerSpeed, rBody.velocity.y);
    }

    public void PlayerDie()
    {
        boxCollider.enabled = false;
        Destroy(this.gameObject, 0.5f);
        sfxManager.PlayerDeath();
        soundManager.StopBGM();
        gameManager.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "CollisionSpikes"){
          PlayerDie();    
        }

        if (other.gameObject.tag == "ColisionMoneda")
        {
            Coin coin = other.gameObject.GetComponent<Coin>();
            coin.Pick();
            gameManager.AddCoin();
        }

        if (other.gameObject.tag == "FinishStage")
        {
            gameManager.NextStage();
            Destroy(this.gameObject);
        } 

        if (other.gameObject.tag == "ToMenu")
        {
            gameManager.ToMenu();
            Destroy(this.gameObject);
        } 
    }

}
