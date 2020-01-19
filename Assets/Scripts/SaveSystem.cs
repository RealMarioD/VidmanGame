using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using vidmanGame;

public class SaveSystem : MonoBehaviour {
    public static string PATH;

    public SaveSystem() {
        PATH = Path.Combine(Application.persistentDataPath, "save.dat");
    }

    public SaveGame loadGame() {
        var fs = File.Open(PATH, FileMode.Open);
        return (SaveGame) new BinaryFormatter().Deserialize(fs);
    }

    public void saveGame(SaveGame save) {
        var fs = File.OpenWrite(PATH);
        new BinaryFormatter().Serialize(fs, save);
    }

    void Start()
    {
        GameManager.saveSystem=this;
    }
}

// This is the savegame itself
[Serializable]
public class SaveGame {
    public int VERSION = 0;

}