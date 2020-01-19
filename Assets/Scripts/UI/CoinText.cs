using System;
using UnityEngine;
using UnityEngine.UI;
using vidmanGame;

public class CoinText : MonoBehaviour {
    protected void Awake() {
        GameManager.CoinsChangeEvent += onCoinsChanged;
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(transform.parent.gameObject);
    }

    void onCoinsChanged(int coins) {
        GameManager.coins=coins;
        GetComponent<Text>().text = $"Coins: {coins}";
    }
}