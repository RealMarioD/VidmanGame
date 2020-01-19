using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActualConsole : Script {

    private Text consoleLog;
    private InputField input;

    // Start is called before the first frame update
    protected override void Awake() {
        base.Awake();

        consoleLog = GetComponentInChildren<Text>();
        input = GetComponentInChildren<InputField>();

        gameObject.SetActive(false);
        gm.ConsoleShowEvent += OnConsoleShow;
        gm.ConsoleHideEvent += OnConsoleHide;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            var cmd = gm.commandHandler.ParseCommand(input.text);
            gm.commandHandler.ExecuteCommand(cmd);
        }
    }

    private void OnConsoleShow() {
        gameObject.SetActive(true);
        input.Select();
    }
    private void OnConsoleHide() {
        gameObject.SetActive(false);
    }
}