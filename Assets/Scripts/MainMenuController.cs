using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{

    public Text highscore;
    public void PlayGame()
    {
        PlayerPrefs.SetInt("lastscore", 0);
        SceneManager.LoadScene("Retroactive");
    }
    
    void Start()
    {
        int hiScore = PlayerPrefs.GetInt("highscore", 0);
        highscore.text = "Current High Score : " + highscore;
    }

    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            PlayGame();
        }
    }
}
