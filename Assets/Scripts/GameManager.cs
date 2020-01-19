using System;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public SaveSystem saveSystem;

    // Events
    public event Action<int> CoinsChangeEvent;
    public event Action ConsoleShowEvent; 
    public event Action ConsoleHideEvent; 

    // Game data
    public int coins;
    public int levelNum { get; private set; } = 1;

    void Awake() {
        saveSystem = new SaveSystem();
        DontDestroyOnLoad(this);
        Application.targetFrameRate = 60;
    }

    public void RaiseCoinsChange(int c) {
        CoinsChangeEvent?.Invoke(c);
    }

    public void RaiseConsoleHide() {
        ConsoleHideEvent?.Invoke();
    }

    public void RaiseConsoleShow() {
        ConsoleShowEvent?.Invoke();
    }
}