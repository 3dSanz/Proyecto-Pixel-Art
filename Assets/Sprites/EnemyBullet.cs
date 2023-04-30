using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody2D rBody2D;
    public float bulletSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rBody2D = GetComponent<Rigidbody2D>();

        rBody2D.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            PlayerController player = collider.gameObject.GetComponent<PlayerController>();
            player.PlayerDie();
            Destroy(this.gameObject);
        }

         if(collider.gameObject.tag != "Player" && collider.gameObject.tag != "ColisionMoneda" && collider.gameObject.tag != "Bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
