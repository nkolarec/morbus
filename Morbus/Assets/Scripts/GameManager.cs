using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region GAME MANAGER PROPERTY

    private static GameManager _GM;

    public static GameManager GM
    {
        get
        {
            if (_GM == null)
                _GM = FindObjectOfType<GameManager>();
            return _GM;
        }
    }

    #endregion

    private GameData _data;

    private void Awake()
    {

        if (_GM == null)
            _GM = this;

        if (_GM != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        // OBRISATI KASNIJE
        if (SceneManager.GetActiveScene().buildIndex != 0)
            _data = new GameData();

    }

    private void Start()
    {
        SaveAndLoadSystemManager.SLSM.GameDataLoad();
    }

    public void GoToLevel()
    {
        SceneManager.LoadScene(_data.Level + 1); // Uvijek je pohranjen zadnji igrani level, zato se nakon UserChoice ide na jedan level viši od pohranjenog.
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToUserChoice()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        _data = SaveAndLoadSystemManager.SLSM.GameData;
    }

    public void SaveGame()
    {
        SaveAndLoadSystemManager.SLSM.GameDataUpdate(_data);
    }

    public void StartGame()
    {
        _data = new GameData();
        SaveAndLoadSystemManager.SLSM.GameDataUpdate(_data);
        GoToUserChoice();
    }

    public void UpdateLevel(int level)
    {
        _data.Level = level;
    }

    // Pozivati kada se dodavaju nove mjere. Neka se uvijek šalju sve aktivne mjere za svaki slučaj.
    // Ne mora nužno argument biti lista.
    public void UpdateMeasures(List<int> measures)
    {
        _data.Measures = measures.ToArray();
    }

    public void UpdateTotalPeople(int people, int peopleInfected)
    {
        _data.TotalPeople += people;
        _data.TotalPeopleInfected += peopleInfected;
    }

    public void TimeReset()
    {
        Time.timeScale = 1;
    }

    public void TimeSpeedUp(float value)
    {
        Time.timeScale = 1 + value;
    }

}
