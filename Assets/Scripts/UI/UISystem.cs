public class UISystem {
    public UIState uiState { get; set; }


    public UISystem() {
        uiState = UIState.Playing; // Initial UI state. will be changed to main menu when it gets implemented!
    }

    public void ChangeUIState(UIState from, UIState to) {
        uiState = to;
        // TODO add validation so we don't mess up when transitioning into/from an invalid state
    }
}

public enum UIState {
    Playing,
    MainMenu,
    EscapeMenu,
    Invalid // if we get to here then we fucked up
}