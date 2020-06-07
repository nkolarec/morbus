using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool isPaused = false;
    public static bool isGamePaused;
    public GameObject pauseMenuUI;
    void Start()
    {
        
    }

    public void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
        }
        else
            Time.timeScale = 0;
            isPaused = true;
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMenu() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Home");

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
