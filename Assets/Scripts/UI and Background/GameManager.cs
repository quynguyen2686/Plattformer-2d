using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Common;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverUI;

    private void OnEnable()
    {
        Heath.PlayerDead += GameOver;
    }

    private void OnDisable()
    {
        Heath.PlayerDead -= GameOver;
    }

    /// <summary>
    /// 
    /// </summary>
    private void GameOver()
    {   
        gameoverUI.SetActive(true);
    }  

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

   public void QUIT()
    {
        Application.Quit();
    }
}
