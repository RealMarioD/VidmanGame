using UnityEngine;

namespace UI {
    public class Console : Script {

        private bool isConsoleOpen = false;

        private void Update() {
            if (Input.GetKeyDown(KeyCode.BackQuote) ||
                Input.GetKeyDown(KeyCode.Tilde) ||
                Input.GetKeyDown(KeyCode.Alpha0)) {
                isConsoleOpen = !isConsoleOpen;
                if (isConsoleOpen) {
                    gm.RaiseConsoleShow();
                }
                else {
                    gm.RaiseConsoleHide();
                }
            }
        }
    }
}