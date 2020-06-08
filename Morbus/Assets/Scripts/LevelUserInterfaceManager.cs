using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUserInterfaceManager : MonoBehaviour
{

    public bool LastLevel;

    public Text endText1;
    public Text endText2;
    public Text endText3;
    public Text endText4;
    public Text endText5;

    public GameObject Header;
    public GameObject PauseMenu;

    public GameObject endCanvas;

    public Text NumbersText;
    public Slider TimeScaleSlider;

    private int _healthy;
    private int _exposed;
    private int _infected;
    private int _total;

    private float _lastTimeScale;

    private bool _exit;
    private float _exitTime = 3;

    private void Start()
    {

        _total = LevelManager.LM.NumberOfPeopleInLevel;
        UpdateNumbers();

        CoronaController.PersonHealthyCreated.AddListener(UpdateNumberOfHealthy);
        CoronaController.PersonInfectedCreated.AddListener(UpdateNumberOfInfected);
        CoronaController.PersonExposed.AddListener(UpdateNumberOfExposed);

        PauseMenu.SetActive(false);
        endCanvas.SetActive(false);

    }

    private void Update()
    {

        if (_exit)
        {
            _exitTime -= Time.deltaTime;

            if (_exitTime < 0)
            {
                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    if (GameManager.GM.DidLose())
                        SceneManager.LoadScene(5);
                    else
                        SceneManager.LoadScene(4);
                }
                else
                    GameManager.GM.GoToUserChoice();
            }
        }

    }

    private void UpdateNumberOfHealthy()
    {
        _healthy++;
        UpdateNumbers();
    }

    private void UpdateNumberOfInfected()
    {
        _infected++;
        UpdateNumbers();
    }

    private void UpdateNumberOfExposed()
    {
        _healthy--;
        _exposed++;
        UpdateNumbers();
    }

    public void UpdateTotal(int total)
    {
        _total = total;
        UpdateNumbers();
    }

    public void UpdateNumbers()
    {
        string healthy = _healthy.ToString("00");
        string exposed = _exposed.ToString("00");
        string infected = _infected.ToString("00");
        string total = (_healthy + _exposed + _infected).ToString("00") + " / " + _total.ToString("00");
        NumbersText.text = String.Format("HEALTHY: {0}   EXPOSED: {1}   INFECTED: {2}   TOTAL: {3}", healthy, exposed, infected, total);
    }

    public void UpdateTimeScale()
    {
        GameManager.GM.TimeSpeedUp(TimeScaleSlider.value);
    }

    public void ShowNumbers(int exposed, int infected, Dictionary<string, int> Stats)
    {

        _exit = true;
        endCanvas.SetActive(true);

        endText1.text = "Out of " + exposed + " exposed " + infected + " developed the disease.";
        endText2.text = Stats["WITH"] + " had the mask and kept the distance.";
        endText3.text = Stats["WITHOUT_MASK"] + " didn't have a mask.";
        endText4.text = Stats["WITHOUT_DISTANCE"] + " didn't keep the distance.";
        endText5.text = Stats["WITHOUT_BOTH"] + " didn't keep the distance and didn't have a mask.";

    }

    public void Pause()
    {
        _lastTimeScale = Time.timeScale;
        Header.SetActive(false);
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Header.SetActive(true);
        PauseMenu.SetActive(false);
        Time.timeScale = _lastTimeScale;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
