using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeUserInterfaceManager : MonoBehaviour
{

    public GameObject PanelMenu;
    //public GameObject PanelHowToPlay;
    //public GameObject PanelSettings;

    public Button LoadGameButton;

    private void Awake()
    {
        PanelMenu.SetActive(true);
        //PanelHowToPlay.SetActive(false);
        //PanelSettings.SetActive(false);
    }

    private void Start()
    {
        if (SaveAndLoadSystemManager.SLSM.GameData == null || SaveAndLoadSystemManager.SLSM.GameData.Level == 0)
        {
            LoadGameButton.interactable = false;
            LoadGameButton.GetComponentInChildren<Text>().color = Color.grey;
        }
    }

    public void StartGame()
    {
        GameManager.GM.StartGame();
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        GameManager.GM.LoadGame();
        SceneManager.LoadScene(SaveAndLoadSystemManager.SLSM.GameData.Level);
    }

    /*
    public void OpenHowToPlay()
    {
        PanelMenu.SetActive(false);
        PanelHowToPlay.SetActive(true);
    }

    public void OpenSettings()
    {
        PanelMenu.SetActive(false);
        PanelSettings.SetActive(true);
    }
    */

    public void Return()
    {
        PanelMenu.SetActive(true);
        //PanelHowToPlay.SetActive(false);
        //PanelSettings.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
