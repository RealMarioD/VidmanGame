using UnityEngine;

public class GameManager : MonoBehaviour {
    
    public SaveSystem saveSystem = new SaveSystem();
    
    void Awake() {
        DontDestroyOnLoad(this);
        Application.targetFrameRate = 60;
    }
}