using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour {

    [SerializeField] Rigidbody2D rb;

    public float noteSpeed = -3;

    public GameObject gameManager;

    void Start() {
        gameManager = GameObject.FindWithTag("GameManager");
    }

    void FixedUpdate() {
        rb.MovePosition(transform.position + Vector3.right * noteSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "collider") {
            if(gameManager.GetComponent<GameManager>().isDead == false) {
                gameManager.GetComponent<GameManager>().AddPoints();
            }
            Destroy(this.gameObject);
        }
    }
}
