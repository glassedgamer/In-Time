using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour {

    public GameObject mainPage;
    public GameObject howToPlay;
    
    GameObject levelChanger;

    void Start() {
        levelChanger = GameObject.FindWithTag("LevelChanger");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        mainPage.SetActive(true);
        howToPlay.SetActive(false);
    }

    public void Home() {
        FindObjectOfType<AudioManager>().Play("Click");
        levelChanger.GetComponent<LevelChanger>().LoadMainMenu();
    }

    public void Retry() {
        FindObjectOfType<AudioManager>().Play("Click");
        levelChanger.GetComponent<LevelChanger>().LoadMainLevel();
    }

    public void Play() {
        FindObjectOfType<AudioManager>().Play("Click");
        levelChanger.GetComponent<LevelChanger>().LoadMainLevel();
    }

    public void HowToPlay() {
        FindObjectOfType<AudioManager>().Play("Click");
        mainPage.SetActive(false);
        howToPlay.SetActive(true);
    }

    public void BackToHome() {
        FindObjectOfType<AudioManager>().Play("Click");
        mainPage.SetActive(true);
        howToPlay.SetActive(false);
    }

}
