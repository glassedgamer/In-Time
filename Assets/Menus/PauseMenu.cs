using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    private PlayerControls playerControls;
    private InputAction menu;
    private InputAction enter;

    GameObject levelChanger;

    [SerializeField] private GameObject pauseUI;
    public bool isPaused;

    void Awake() {
        playerControls = new PlayerControls();
    }

    void Start() {
        levelChanger = GameObject.FindWithTag("LevelChanger");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnEnable() {
        menu = playerControls.Menu.Pause;
        enter = playerControls.Menu.Enter;
        menu.Enable();
        enter.Enable();

        menu.performed += Pause;
        enter.performed += MainMenu;
    }

    void OnDisable() {
        menu.Disable();
        enter.Disable();
    }

    void Pause(InputAction.CallbackContext context) {
        isPaused = !isPaused;

        if(isPaused) {
            ActivateMenu();
        } else {
            DeactivateMenu();
        }
    }

    void MainMenu(InputAction.CallbackContext context) {
        if(isPaused) {
            DeactivateMenu();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            // FindObjectOfType<AudioManager>().Stop("GZG Division");
            levelChanger.GetComponent<LevelChanger>().LoadMainMenu();
        } else {
            return;
        }
        
    }

    void ActivateMenu() {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseUI.SetActive(true);
    }

    public void DeactivateMenu() {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        pauseUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
    }
}
