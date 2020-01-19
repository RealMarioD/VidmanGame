using System;
using UnityEngine;

namespace VidmanGame {
    public static class GameManager {

        public static SaveSystem saveSystem;

        // Events
        public static event Action<int> CoinsChangeEvent;

        // Game data
        public static int coins;
        public static int levelNum { get; private set; } = 1;

        public static void Awake() {
            saveSystem = new SaveSystem();
            Application.targetFrameRate = 60;
        }

        public static void RaiseCoinsChange(int c) {
            CoinsChangeEvent?.Invoke(c);
        }
    }
}