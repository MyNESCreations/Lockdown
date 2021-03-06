﻿//Name: Tristan Burger
//Date: 10/9/2016

//Purpose: Managing the pressing and use of buttons

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    [SerializeField]
    GameObject controls;

    [SerializeField]
    GameObject credits;

    public bool opening;
    void Start()
    {
        if (controls)
        {
            if (!opening)
                controls.SetActive(false);
        }
    }


    public void Quit ()
    {
        Application.Quit();
    }

    public void ToggleControles ()
    {
        controls.SetActive(!controls.activeInHierarchy);
        uiStatsManager.isPaused = !uiStatsManager.isPaused;
        if (uiStatsManager.isPaused)
            Time.timeScale = 0;
        if (!uiStatsManager.isPaused)
            Time.timeScale = 1;
    }

    public void Credits()
    {
        controls.SetActive(false);
        credits.SetActive(true);
    }
    public void Controls()
    {
        controls.SetActive(true);
        credits.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
