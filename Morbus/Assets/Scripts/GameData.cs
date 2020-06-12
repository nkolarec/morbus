using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{

    public int Level = 1;
    public int[] Measures = new int[0];

    public int TotalPeople;
    public int TotalPeopleInfected;

    public GameData() { }

    public GameData(int level, int[] measures, int total, int totalInfected)
    {
        Level = level;
        Measures = measures;
        TotalPeople = total;
        TotalPeopleInfected = totalInfected;
    }

}
