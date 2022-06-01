using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text scoreText;
    public GameObject gameOverText;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        scoreText.text = "SCORE : " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        score += 100;
        scoreText.text = "SCORE : " + score;
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
    }
}
