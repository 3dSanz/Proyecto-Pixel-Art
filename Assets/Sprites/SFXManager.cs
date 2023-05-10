using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip enemyDeath;
    public AudioClip playerDeath;
    public AudioClip itemPick;
    public AudioClip playerJump;
    public AudioClip playerShoot;
    public AudioClip enemyShoot;
    public AudioClip playerMelee;


    private AudioSource source;

    void Awake()
    {
     DontDestroyOnLoad(this.gameObject);
     source = GetComponent<AudioSource>();

    }

    public void EnemyDied() 
    {
         source.PlayOneShot(enemyDeath);
    }

    public void PlayerDeath() 
    {
         source.PlayOneShot(playerDeath);
    }
    
    public void ItemPick() 
    {
         source.PlayOneShot(itemPick);
    }

    public void PlayerJump() 
    {
         source.PlayOneShot(playerJump);
    }

    public void PlayerShoot() 
    {
         source.PlayOneShot(playerShoot);
    }

    public void PlayerMelee() 
    {
         source.PlayOneShot(playerMelee);
    }

    public void EnemyShoot() 
    {
         source.PlayOneShot(enemyShoot);
    }

}
