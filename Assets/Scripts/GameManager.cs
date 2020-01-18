using UnityEngine;

public class GameManager : MonoBehaviour {
    
    public SaveSystem saveSystem;
    
    void Awake() {
        saveSystem = new SaveSystem();
        DontDestroyOnLoad(this);
        Application.targetFrameRate = 60;
    }
}