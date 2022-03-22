using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{

    public GameObject asteroid;
    public Vector3 randomPos;

    private int counter = 0;

    public Text scoreText;
    public Text gameOverText;
    public Text restartText;

    int score;

    bool isGameOver = false;
    float wait = 0;
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;

        gameOverText.text = "";
        restartText.text = "";
    }

    void FixedUpdate()
    {
        if(isGameOver) {
            wait += Time.fixedDeltaTime;
        }

        counter++;
        if(counter > 20 && !isGameOver) {
            counter = 0;
            randomPos = new Vector3(Random.value * 12.0f - 6.0f, 0, 15);
            Generate();
        }

       
    }

    private void Update() {
        if (isGameOver && Input.GetKeyDown(KeyCode.R) && wait > 1.0f) {
            Restart();
        }
    }

    void Generate() {
        Instantiate(asteroid, randomPos, Quaternion.identity);
    }

    public void IncreaseScore(int inc) {
        score += inc;
        scoreText.text = "Score: " + score;
    }

    public void GameOver() {
        isGameOver = true;

        gameOverText.text = "GAME OVER";
        restartText.text = "PRESS R TO RESTART";
    }

    private void Restart() {
        SceneManager.LoadScene("SampleScene");
    }
}
