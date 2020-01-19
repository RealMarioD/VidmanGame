public class ActualConsole : Script {
    // Start is called before the first frame update
    protected override void Awake() {
        base.Awake();
        gameObject.SetActive(false);
        gm.ConsoleShowEvent += OnConsoleShow;
        gm.ConsoleHideEvent += OnConsoleHide;
    }

    private void OnConsoleShow() {
        gameObject.SetActive(true);
    }
    private void OnConsoleHide() {
        gameObject.SetActive(false);
    }
}