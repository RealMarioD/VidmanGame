using UnityEngine;

namespace UI {
    public class Console : Script {
        

        private void Update() {
            if (Input.GetKeyDown(KeyCode.BackQuote) ||
                Input.GetKeyDown(KeyCode.Tilde) ||
                Input.GetKeyDown(KeyCode.Alpha0)) {
                gm.isConsoleOpen = !gm.isConsoleOpen;
                if (gm.isConsoleOpen) {
                    gm.RaiseConsoleShow();
                }
                else {
                    gm.RaiseConsoleHide();
                }
            }
        }
    }
}