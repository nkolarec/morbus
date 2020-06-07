using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceUserInterfaceManager : MonoBehaviour
{
    public Text MeasureName1;
    public Text MeasureDescription1;
    public Text MeasurePros1;
    public Text MeasureCons1;

    public Text MeasureName2;
    public Text MeasureDescription2;
    public Text MeasurePros2;
    public Text MeasureCons2;

    public Text MeasureName3;
    public Text MeasureDescription3;
    public Text MeasurePros3;
    public Text MeasureCons3;

    public Text NextLevelRequirements;

    public Button Measure1;
    public Button Measure2;
    public Button Measure3;

    private Measure chosenMeasure;

    public List<Measure> activeMeasures;

    //TODO: treba promijeniti u manageru da se globalno savea, kad se dvaput ide naprijed-nazad (exit to menu se dvaput ide i start pa me baci na user choice) Unity se zmrzne
    //TODO: treba mijenjati next level description za svaki sljedeci level
    private void Awake()
    {
       
        activeMeasures = Measure.GetActiveMeasures();

        MeasureName1.text = activeMeasures[0].Name;
        MeasureDescription1.text = activeMeasures[0].Description;
        MeasurePros1.text = activeMeasures[0].Pros;
        MeasureCons1.text = activeMeasures[0].Cons;

        MeasureName2.text = activeMeasures[1].Name;
        MeasureDescription2.text = activeMeasures[1].Description;
        MeasurePros2.text = activeMeasures[1].Pros;
        MeasureCons2.text = activeMeasures[1].Cons;

        MeasureName3.text = activeMeasures[2].Name;
        MeasureDescription3.text = activeMeasures[2].Description;
        MeasurePros3.text = activeMeasures[2].Pros;
        MeasureCons3.text = activeMeasures[2].Cons;

        NextLevelRequirements.text = "WARNING: People will be obliged to wear masks.";

        Measure1.onClick.AddListener(() => SetChosenMeasure(activeMeasures[0]));
        Measure2.onClick.AddListener(() => SetChosenMeasure(activeMeasures[1]));
        Measure3.onClick.AddListener(() => SetChosenMeasure(activeMeasures[2]));
    }

    public void SetChosenMeasure(Measure measure)
    {
        chosenMeasure = measure;
    }

    public Measure GetChosenMeasure()
    {
        return chosenMeasure;
    }
}
