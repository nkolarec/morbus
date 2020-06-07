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
    }
}
