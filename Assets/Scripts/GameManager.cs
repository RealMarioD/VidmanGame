using UnityEngine;

public class GameManager : MonoBehaviour {

    void Awake() {
        DontDestroyOnLoad(this);
        Application.targetFrameRate = 60;
    }
}