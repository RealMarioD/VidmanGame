using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    public SaveSystem saveSystem;
    
    // Events
    public event Action<int> CoinsChangeEvent;
    
    // Game data
    public int coins;
    public int levelNum {get; private set;} = 1;
    void Awake() {
        saveSystem = new SaveSystem();
        DontDestroyOnLoad(this);
        Application.targetFrameRate = 60;
    }

    public void OnCoinsChangeEvent(int c) {
        CoinsChangeEvent?.Invoke(c);
    }
}