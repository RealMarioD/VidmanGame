using System;
using UnityEngine;

public class Script : MonoBehaviour {
    protected GameManager gm;

    protected virtual void Awake() {
        gm = FindObjectOfType<GameManager>();
    }
}