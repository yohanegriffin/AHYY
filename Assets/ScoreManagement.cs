using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagement : MonoBehaviour {

    public static ScoreManagement instance;

    public Text scoreText;
    public Text highscoreText;

    int score = 0;
    int highscore = 0;

    private void Awake() {
        instance = this; 
    }

     //With reference variable
     public roundController RoundController;

    void Start()
    {
        // Accessing a method in roundController
        RoundController.Update();
        highscore=PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void AddPoint() {
        score += 1;
        scoreText.text = score.ToString() + " POINTS";
        if(highscore<score){
            PlayerPrefs.SetInt("highscore", score);
        }

    }
}
