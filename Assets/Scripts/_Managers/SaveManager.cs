using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;

public class SaveManager : Singleton<SaveManager>
{
    public static void SaveSettingsData(SettingsData currentInfo) {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/Settings.dat", FileMode.Create);

        bf.Serialize(stream, currentInfo);

        stream.Close();
    }

    public static SettingsData LoadSettingsData() {
        SettingsData storedInfo = new SettingsData();

        if(File.Exists(Application.persistentDataPath + "/Settings.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/Settings.dat", FileMode.Open);
            storedInfo = bf.Deserialize(stream) as SettingsData;

            stream.Close();
        }

        return storedInfo;
    }
}
