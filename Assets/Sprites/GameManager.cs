using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    public Text coinText;
    int contMonedas;
    public bool canShoot;
    public bool enemyShoot;
    public bool plMelee;
    public float powerUpDuration = 1;
    public float powerUpTimer = 0;
    public float enemyTL = 1;
    public float enemyTimer = 0;
    public float meleeTL = 1;
    public float meleeTimer = 0;

    void Start()
    {
        canShoot = true;
        enemyShoot = true;

    }
   
   public void GameOver()
    {
        isGameOver = true;
        StartCoroutine("LoadScene");
    }

    void Update()
    {
        PlayerShoot();
        EnemyShoot();
        PlayerMelee();
    }

  IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(2);
    }

    void PlayerShoot()
    {

            if(powerUpTimer <= powerUpDuration)
            {
                powerUpTimer += Time.deltaTime;
                canShoot = false;
            }else
            {
                canShoot = true;
            }
        
    }

        public void AddCoin()
    {
        contMonedas++;
        coinText.text = "coin " + contMonedas.ToString();
    }

    void EnemyShoot()
    {

            if(enemyTimer <= enemyTL)
            {
                enemyTimer += Time.deltaTime;
                enemyShoot = false;
            }else
            {
                enemyShoot = true;
            }
        
    }

        void PlayerMelee()
    {

            if(meleeTimer <= meleeTL)
            {
                meleeTimer += Time.deltaTime;
                plMelee = false;
            }else
            {
                plMelee = true;
            }
        
    }
}
