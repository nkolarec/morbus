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

    public List<Measure> activeMeasures;

    // ne radi iz nekog razloga, Unity prestane reagirat na pokretanje te scene
    /*private void Awake()
    {
        activeMeasures = Measure.GetActiveMeasures();
        MeasureName1.text = activeMeasures[0].Name;
        MeasureDescription1.text = activeMeasures[0].Description;
        MeasurePros1.text = activeMeasures[0].Pros;
        MeasureCons1.text = activeMeasures[0].Cons;

        MeasureName1.text = activeMeasures[1].Name;
        MeasureDescription1.text = activeMeasures[1].Description;
        MeasurePros1.text = activeMeasures[1].Pros;
        MeasureCons1.text = activeMeasures[1].Cons;

        MeasureName1.text = activeMeasures[2].Name;
        MeasureDescription1.text = activeMeasures[2].Description;
        MeasurePros1.text = activeMeasures[2].Pros;
        MeasureCons1.text = activeMeasures[2].Cons;

    } */
}
