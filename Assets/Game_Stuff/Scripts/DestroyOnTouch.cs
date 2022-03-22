using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour {

    public GameObject asteroid;

    public GameObject explosion_Asteroid;
    public GameObject explosion_Player;

    GameObject gameControl;
    GameControl control;


    private void Start() {
        gameControl = GameObject.FindGameObjectWithTag("GameControl");
        control = gameControl.GetComponent<GameControl>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Bullet") {
            Destroy(other.gameObject);
            Destroy(asteroid);

            Instantiate(explosion_Asteroid, transform.position, transform.rotation);
            control.IncreaseScore(1);
        }

        if (other.tag == "Player") {
            Destroy(other.gameObject);
            Destroy(asteroid);

            Instantiate(explosion_Player, transform.position, transform.rotation);
            control.GameOver();
        }
    }

    private void FixedUpdate() {
        
    }

}
