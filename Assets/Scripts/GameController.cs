using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Text scoreText;
    public GameObject gameOverText;
    public GameObject nextSceneText;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        nextSceneText.SetActive(false);
        scoreText.text = "SCORE : " + score;

        
    }

    // Update is called once per frame
    void Update()
    {             
                
        if (gameOverText.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                //ÉXÉRÉAÇÃï€ë∂
                PlayerPrefs.SetInt("Score", score);
                PlayerPrefs.Save();


                //scoreText.text = PlayerPrefs.SetInt();

                SceneManager.LoadScene("Result");

               
            }

        }

        if (SceneManager.GetActiveScene().name == "Result")
            {
            //PlayerPrefs.GetInt("Score");
            scoreText.text = "Score : " + PlayerPrefs.GetInt("Score").ToString() + "kg";

            }
        
    }

    public void AddScore1()
    {     
        score += 100;
        scoreText.text = "SCORE : " + score + "kg";
        
    }

    public void AddScore2()
    {
        score += 300;
        scoreText.text = "SCORE : " + score + "kg";
    }


    public void GameOver()
    {
        gameOverText.SetActive(true);
        nextSceneText.SetActive(true);

    }
    
}
