using System;
using UnityEngine;

// new controller lol
public class Player2 : MonoBehaviour {

    public Vector3 velocity;

    public void Update() {
        velocity.y = -0.9f * Time.deltaTime;
    }
}