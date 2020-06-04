using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{

    public int Level;
    public int[] Measures;

    public GameData() { }

    public GameData(int level, int[] measures)
    {
        Level = level;
        Measures = measures;
    }

}
