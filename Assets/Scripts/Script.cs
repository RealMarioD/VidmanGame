using System;
using UnityEngine;

public class Script : MonoBehaviour {
    protected GameManager gm;

    void Awake() {
        gm = FindObjectOfType<GameManager>();
    }
}