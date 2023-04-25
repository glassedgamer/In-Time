using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    
    WaitForSeconds noteDelay;

    GameObject levelChanger;

    public bool isDead = false;

    [Header("Metronome")]
    public float timeBetweenNotes = 2f;

    float count = 0;
    float measureCount = 0;
    public GameObject tempoIndicator;

    [Header("Notes")]
    public GameObject noteDown;
    public GameObject noteUp;

    public Transform noteDownStartPos;
    public Transform noteUpStartPos;

    float nSpeed;

    [Header("Points")]
    public int pointValue = 1;

    public int points = 0;
    public int highscore = 0;

    [Header("Score Text")]
    public Text scoreText;
    public Text highscoreText;

    [Header("UI")]
    public float startDelay;
    public Text countIn;

    void Start() {
        isDead = false;

        levelChanger = GameObject.FindWithTag("LevelChanger");

        nSpeed = noteDown.GetComponent<NoteManager>().noteSpeed;
        noteDelay = new WaitForSeconds(timeBetweenNotes);

        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = points.ToString() + " Points";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();

        StartCoroutine(noteSpawn());
    }

    void Update() {
    }

    IEnumerator noteSpawn() {
        //Wait a few seconds to start
        countIn.gameObject.SetActive(false);
        tempoIndicator.SetActive(false);
        yield return new WaitForSeconds(startDelay);

        //Activates intro count in
        countIn.gameObject.SetActive(true);
        tempoIndicator.SetActive(true);

        //Countin
        for (int i = 1; i < 5; i++) {
            countIn.text = i.ToString();

            if(i == 1) {
                tempoIndicator.transform.position = new Vector2(-6.01825f, 3.71625f);
                FindObjectOfType<AudioManager>().Play("Wood Block");
            } else if(i == 2) {
                tempoIndicator.transform.position = new Vector2(-5.20125f, 3.71625f);
                FindObjectOfType<AudioManager>().Play("Wood Block");
            } else if(i == 3) {
                tempoIndicator.transform.position = new Vector2(-4.40325f, 3.71625f);
                FindObjectOfType<AudioManager>().Play("Wood Block");
            } else if(i == 4) {
                countIn.text = "Begin!";
                tempoIndicator.transform.position = new Vector2(-3.605251f, 3.71625f);
                FindObjectOfType<AudioManager>().Play("Wood Block");
                count = 0;
            }
            yield return noteDelay;
        }
        //Deactivates count in
        countIn.gameObject.SetActive(false);

        //Spawn the notes
        StartCoroutine(metronome());
    }

    IEnumerator metronome() {
        while (true) {
            count++;
            int randomInt = Random.Range(0, 2);
            if(randomInt == 0) {
                Instantiate(noteDown, noteDownStartPos.transform.position, Quaternion.identity);
                FindObjectOfType<AudioManager>().Play("F");
            } else if(randomInt == 1) {
                Instantiate(noteUp, noteUpStartPos.transform.position, Quaternion.identity);
                FindObjectOfType<AudioManager>().Play("G");
            }

            if(count == 1) {
                TimeIncrease();
                tempoIndicator.transform.position = new Vector2(-6.01825f, 3.71625f);
                FindObjectOfType<AudioManager>().Play("Wood Block");
            } else if(count == 2) {
                tempoIndicator.transform.position = new Vector2(-5.20125f, 3.71625f);
                FindObjectOfType<AudioManager>().Play("Wood Block");
            } else if(count == 3) {
                tempoIndicator.transform.position = new Vector2(-4.40325f, 3.71625f);
                FindObjectOfType<AudioManager>().Play("Wood Block");
            } else if(count == 4) {
                tempoIndicator.transform.position = new Vector2(-3.605251f, 3.71625f);
                FindObjectOfType<AudioManager>().Play("Wood Block");
                count = 0;
                measureCount++;
            }

            yield return noteDelay;
        }
    }

    public void Death() {
        isDead = true;
        levelChanger.GetComponent<LevelChanger>().LoadDedMenu();
    }

    public void AddPoints() {
        points += pointValue;
        scoreText.text = points.ToString() + " Points";
        if(highscore < points) {
            PlayerPrefs.SetInt("highscore", points);
        }
    }

    void TimeIncrease() {
        if(measureCount % 4 == 0 && measureCount != 0 && timeBetweenNotes > 0.9399996f) {
            Debug.Log("Tempo Change");

            timeBetweenNotes -= 0.07f;
            nSpeed -= 0.07f;

            noteDelay = new WaitForSeconds(timeBetweenNotes);
        }
    }

}
