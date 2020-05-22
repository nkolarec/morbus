using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadSystemManager : MonoBehaviour
{

    #region SAVE AND LOAD SYSTEM MANAGER PROPERTY

    private static SaveAndLoadSystemManager _SLSM;
    
    public static SaveAndLoadSystemManager SLSM
    {
        get
        {
            if (_SLSM == null)
                _SLSM = FindObjectOfType<SaveAndLoadSystemManager>();
            return _SLSM;
        }
    }

    #endregion

    public GameData GameData
    {
        get;
        private set;
    }

    private void Awake()
    {

        if (_SLSM == null)
            _SLSM = this;

        if (_SLSM != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

    public void GameDataLoad()
    {
        GameData = BinarySerializer.GameDataLoad();
    }

    public void GameDataSave()
    {
        BinarySerializer.GameDataSave(GameData);
    }

    public void GameDataUpdate(GameData data)
    {
        GameData = data;
        GameDataSave();
    }

}
