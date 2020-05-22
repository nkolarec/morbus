using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }

    private void Start()
    {
        SaveAndLoadSystemManager.SLSM.GameDataLoad();
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
    }

    public void UpdateLevel(int level)
    {
        _data.Level = level;
    }

}
