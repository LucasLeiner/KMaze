using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{

    public Text scoreText;
    public Text highScoreText;
    public static int score;
    public static int highScore;

    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
    }

    void Update()
    {
        scoreText.text = "Score : " + score;
        highScoreText.text = "High Score : " + highScore;
    }
}
