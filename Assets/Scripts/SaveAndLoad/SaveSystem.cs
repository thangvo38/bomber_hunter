using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem {
    public static void SaveGame (int lives, int bombs, string stageName, int fileNumber) {
        BinaryFormatter formatter = new BinaryFormatter ();
        string path = Application.persistentDataPath + "/" + fileNumber + ".save";
        FileStream stream = new FileStream (path, FileMode.Create);

        SaveData data = new SaveData (lives, bombs, stageName, fileNumber);
        formatter.Serialize (stream, data);
        stream.Close ();
    }
    public static SaveData LoadGame (int fileNumber) {
        string path = Application.persistentDataPath + "/" + fileNumber + ".save";
        if (File.Exists (path)) {
            BinaryFormatter formatter = new BinaryFormatter ();
            FileStream stream = new FileStream (path, FileMode.Open);

            SaveData data = formatter.Deserialize (stream) as SaveData;
            stream.Close ();

            return data;
        } else {
            Debug.Log ("Save file not found");
            return null;
        }
    }
}