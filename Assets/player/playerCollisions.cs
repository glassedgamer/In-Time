using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollisions : MonoBehaviour {

    GameObject gameManager;

    void Start() {
        gameManager = GameObject.FindWithTag("GameManager");
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "notes") {
            gameManager.GetComponent<GameManager>().Death();
            FindObjectOfType<AudioManager>().Play("Die");
            Destroy(this.gameObject);
        }
    }

}
