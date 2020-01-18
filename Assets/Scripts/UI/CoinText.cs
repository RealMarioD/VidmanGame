using System;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : Script {
    protected override void Awake() {
        base.Awake();
        gm.CoinsChangeEvent += onCoinsChanged;
    }

    void onCoinsChanged(int coins) {
        GetComponent<Text>().text = $"Coins: {coins}";
    }
}