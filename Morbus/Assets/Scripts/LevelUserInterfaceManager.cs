using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUserInterfaceManager : MonoBehaviour
{
    public Text endText1;
    public Text endText2;
    public Text endText3;
    public Text endText4;
    public Text endText5;

    public GameObject endCanvas;

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

    public void ShowNumbers(int exposed, int infected, Dictionary<string, int> Stats)
    {
        endCanvas.SetActive(true);

        endText1.text = "Out of " + exposed + " exposed " + infected + " developed the disease.";
        endText2.text = "Had the mask and kept the distance: " + Stats["WITH"];
        endText3.text = "Didn't have the mask: " + Stats["WITHOUT_MASK"];
        endText4.text = "Didn't keep the distance: " + Stats["WITHOUT_DISTANCE"];
        endText5.text = "Didn't keep the distance or have a mask: " + Stats["WITHOUT_BOTH"];

    }

}
