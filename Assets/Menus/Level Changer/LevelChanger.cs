using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelChanger : MonoBehaviour {

    public Animator anim;

    public float transitionTime = 2f;

    // public void LoadNextLevel() {
    //     StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    // }

    public void LoadDedMenu() {
        StartCoroutine(LoadLevel(2));
    }

    public void LoadMainLevel() {
        StartCoroutine(LoadLevel(1));
    }

    public void LoadMainMenu() {
        StartCoroutine(LoadLevel(0));
    }

    public IEnumerator LoadLevel(int levelIndex) {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

}
