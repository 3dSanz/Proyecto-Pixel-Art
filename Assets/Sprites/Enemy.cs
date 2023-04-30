using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 public float speed;
    float horizontal = 1;
    Animator anim;
    BoxCollider2D boxCollider;
    Rigidbody2D rBody;
    GameManager gameManager;
    public GameObject enemyBulletPrefab;
    public Transform enemyBulletSpawn;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        rBody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    void Update()
    {
            Invoke("EnemyShoot", 1.5f);
    }

    void EnemyShoot()
    {
        Instantiate(enemyBulletPrefab, enemyBulletSpawn.position, enemyBulletSpawn.rotation);
    }

    void FixedUpdate()
    {
        rBody.velocity = new Vector2 (horizontal*speed, rBody.velocity.y);
    }

    public void Die()
    {
        boxCollider.enabled = false;
        Destroy(this.gameObject, 0.5f);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);

        }   

        if (collision.gameObject.tag == "ColisionEnemy")
        {
            if (horizontal == 1)
            {
                horizontal = -1;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }else 
            {
                horizontal = 1;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        } 
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "ColisionEnemy")
        {
            if (horizontal == 1)
            {
                horizontal = -1;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }else 
            {
                horizontal = 1;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        } 
    }
}
