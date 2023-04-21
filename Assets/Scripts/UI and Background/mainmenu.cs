using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Common;

public class mainmenu : MonoBehaviour
{
   public void playgame()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    public void quitgame()
    {

        Application.Quit();
    }
}
