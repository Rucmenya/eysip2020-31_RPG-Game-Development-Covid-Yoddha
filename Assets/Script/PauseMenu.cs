﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenuUI;
    public EXP Exp;
    GameObject G;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        Exp.GamePause = true;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        Exp.GamePause = false;
    }
    public void MainMenu()
    {
        G = FindObjectOfType<CharecterMovement>().gameObject;
        Time.timeScale = 1f;
        gamePaused = false;
        Exp.CharecterPresent = false;
        Exp.GameTime = 0;
        SceneManager.LoadScene("MainMenu");
        Destroy(G);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}