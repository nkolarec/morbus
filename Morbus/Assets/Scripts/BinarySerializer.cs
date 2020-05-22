using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class BinarySerializer
{

    public static GameData GameDataLoad()
    {

        string path = Application.persistentDataPath + "/GameData.dat";

        if (File.Exists(path) == false)
            return null;

        FileStream file = File.Open(path, FileMode.Open);
        BinaryFormatter formatter = new BinaryFormatter();
        GameData data = (GameData)formatter.Deserialize(file);
        file.Close();

        return data;

    }

    public static void GameDataSave(GameData data)
    {

        string path = Application.persistentDataPath + "/GameData.dat";

        FileStream file = File.Create(path);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(file, data);
        file.Close();

    }

}
