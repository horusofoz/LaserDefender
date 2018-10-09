﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

	public void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void LoadLeve01()
    {
        SceneManager.LoadScene("Level01");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
