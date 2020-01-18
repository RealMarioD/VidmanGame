using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem {
    public static readonly string PATH = Path.Combine(Application.persistentDataPath, "save.dat");

    public SaveSystem() {
        // nothing so far
    }

    public SaveGame loadGame() {
        var fs = File.Open(PATH, FileMode.Open);
        return (SaveGame) new BinaryFormatter().Deserialize(fs);
    }

    public void saveGame(SaveGame save) {
        var fs = File.OpenWrite(PATH);
        new BinaryFormatter().Serialize(fs, save);
    }
}

// This is the savegame itself
[Serializable]
public class SaveGame {
    public int VERSION = 0;

}