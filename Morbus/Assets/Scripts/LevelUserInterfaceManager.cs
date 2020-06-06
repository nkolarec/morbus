using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUserInterfaceManager : MonoBehaviour
{

    public Text NumbersText;
    public Slider TimeScaleSlider;

    private int _healthy;
    private int _exposed;
    private int _infected;
    private int _total;

    private void Start()
    {

        _total = LevelManager.LM.NumberOfPeopleInLevel;
        UpdateNumbers();

        CoronaController.PersonHealthyCreated.AddListener(UpdateNumberOfHealthy);
        CoronaController.PersonInfectedCreated.AddListener(UpdateNumberOfInfected);
        CoronaController.PersonExposed.AddListener(UpdateNumberOfExposed);

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

}
