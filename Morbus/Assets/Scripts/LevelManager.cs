using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public LevelUserInterfaceManager luim;

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
    public Vector3 CheckoutExitPoint;
    public Vector3 BuildingExitPoint;
    public Vector3 SceneExitPoint;

    public List<Vector3> AccessiblePoints = new List<Vector3>();

    [Header("People")]

    public int NumberOfInfectedPeopleInLevel;
    public int NumberOfPeopleInLevel;

    [HideInInspector]
    public Dictionary<string, int> Stats = new Dictionary<string, int>();

    private int _numberOfPeopleExposed;
    private int _numberOfPeopleNewlyInfected;
    private int _numberOfPeopleDestroyed;

    private void Awake()
    {

        CoronaController.PersonDestroyed.AddListener(PersonDestroyed);
        Time.timeScale = 1;

        Stats.Add("WITH", 0);
        Stats.Add("WITHOUT_MASK", 0);
        Stats.Add("WITHOUT_DISTANCE", 0);
        Stats.Add("WITHOUT_BOTH", 0);

        GameManager.GM.UpdateLevel(SceneManager.GetActiveScene().buildIndex);
        GameManager.GM.SaveGame();

    }

    private void PersonDestroyed(bool _exposed, float percentage, bool distance, bool mask)
    {

        _numberOfPeopleDestroyed++;

        if (_exposed)
        {

            _numberOfPeopleExposed++;

            float contagion = Random.Range(0.0f, 1.0f);

            if (contagion <= percentage)
            {

                _numberOfPeopleNewlyInfected++;

                if (distance == true && mask == true)
                    Stats["WITH"]++;

                if (distance == true && mask == false)
                    Stats["WITHOUT_MASK"]++;

                if (distance == false && mask == false)
                    Stats["WITHOUT_BOTH"]++;

                if (distance == false && mask == true)
                    Stats["WITHOUT_DISTANCE"]++;

            }

        }

        if (_numberOfPeopleDestroyed == NumberOfPeopleInLevel)
        {
            GameManager.GM.UpdateTotalPeople(NumberOfPeopleInLevel, _numberOfPeopleNewlyInfected);
            ShowStats();
        }

    }

    private void ShowStats()
    {
        Time.timeScale = 1;
        Debug.Log(_numberOfPeopleExposed + " exposed.");
        Debug.Log(_numberOfPeopleNewlyInfected + " developed the disease.");
        Debug.Log("Had the mask and kept the distance: " + Stats["WITH"]);
        Debug.Log("Didn't have the mask: " + Stats["WITHOUT_MASK"]);
        Debug.Log("Didn't keep the distance: " + Stats["WITHOUT_DISTANCE"]);
        Debug.Log("Didn't keep the distance and didn't have a mask: " + Stats["WITHOUT_BOTH"]);
        luim.ShowNumbers(_numberOfPeopleExposed, _numberOfPeopleNewlyInfected, Stats);
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
        resultPoints.Add(CheckoutExitPoint);
        resultPoints.Add(BuildingExitPoint);
        resultPoints.Add(SceneExitPoint);

        return resultPoints;

    }

}
