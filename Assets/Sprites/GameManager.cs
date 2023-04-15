using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
public bool isGameOver = false;

   public void GameOver()
    {
        isGameOver = true;
        StartCoroutine("LoadScene");
    }

  IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(1);
    }
}
