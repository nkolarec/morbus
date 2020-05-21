using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeUserInterfaceManager : MonoBehaviour
{

    public GameObject PanelMenu;
    public GameObject PanelHowToPlay;
    public GameObject PanelSettings;

    private void Awake()
    {
        PanelMenu.SetActive(true);
        PanelHowToPlay.SetActive(false);
        PanelSettings.SetActive(false);
    }

    public void StartGame()
    {
        // Resetirati sve podatke u GameManager-u (za svaki slučaj) i pokrenuti scenu s
        // indeksom 1.
    }

    public void LoadGame()
    {
        // Otvoriti izbornik za izbor save-a ili odmah dohvatiti podatke u GameManager-u
        // i pokrenuti odgovarajuću scenu.
    }

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

    public void Return()
    {
        PanelMenu.SetActive(true);
        PanelHowToPlay.SetActive(false);
        PanelSettings.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
