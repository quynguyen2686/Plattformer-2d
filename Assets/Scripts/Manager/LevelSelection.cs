using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public int level;
    public TMP_Text leveltext;
    private void Start()
    {
        leveltext.text=level.ToString() ;
    }
    public void openscene()
    {
        SceneManager.LoadScene("Level " + level.ToString());
    }
  
}
