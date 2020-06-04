using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    #region LEVEL MANAGER PROPERTY

    private static LevelManager _LM;

    public static LevelManager LM
    {
        get
        {
            if (_LM == null)
                _LM = FindObjectOfType<LevelManager>();
            return _LM;
        }
    }

    #endregion

    public int NumberOfPoints
    {
        get
        {
            return AccessiblePoints.Count;
        }
    }

    [Header("Points")]

    public Vector3 BuildingEntryPoint;
    public Vector3 CheckoutEntryPoint;
    public Vector3 BuildingExitPoint;
    public Vector3 SceneExitPoint;

    public List<Vector3> AccessiblePoints = new List<Vector3>();

    [Header("People")]

    public int NumberOfInfectedPeopleInLevel;
    public int NumberOfPeopleInLevel;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    public List<Vector3> GetPoints(int number)
    {

        List<Vector3> resultPoints = new List<Vector3>();

        resultPoints.Add(BuildingEntryPoint);

        while (resultPoints.Count < number)
        {
            Vector3 point = AccessiblePoints[Random.Range(0, AccessiblePoints.Count - 1)];
            if (resultPoints.Contains(point) == false)
                resultPoints.Add(point);
        }

        resultPoints.Add(CheckoutEntryPoint);
        resultPoints.Add(BuildingExitPoint);
        resultPoints.Add(SceneExitPoint);

        return resultPoints;

    }

}
