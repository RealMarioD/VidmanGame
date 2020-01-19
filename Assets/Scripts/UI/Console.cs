using System;
using UnityEngine;

namespace UI {
    public class Console : MonoBehaviour {
        private void Update() {
            if (Input.GetKeyDown(KeyCode.BackQuote) || 
                Input.GetKeyDown(KeyCode.Tilde) ||
                Input.GetKeyDown(KeyCode.Alpha0)) {
                
            }
        }
    }
}