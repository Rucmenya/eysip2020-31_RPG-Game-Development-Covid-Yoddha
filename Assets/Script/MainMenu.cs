using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public EXP Exp;

    public void PlayGame()
    {
        Debug.Log("works");
        Debug.Log("Yeah it Works , LOL");


        Exp.GamePause = false;
        Exp.GameTime = 0;
        Exp.CharecterPresent = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    } 

    public void QuitGame()
    {
        Application.Quit();
    }
}
