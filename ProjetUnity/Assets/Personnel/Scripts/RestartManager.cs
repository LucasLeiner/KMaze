using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartManager : MonoBehaviour
{

    public GameObject gameOver, heart0, heart1, heart2, heart3;
    public static int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        heart1.SetActive(true); 
        heart2.SetActive(true);
        heart3.SetActive(true);
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (health)
        {
            case 3:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                break;

            case 2:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(false);
                break;

            case 1:
                heart1.SetActive(true);
                heart2.SetActive(false);
                heart3.SetActive(false);
                break;

            default:
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                gameOver.SetActive(true);
                scoreManager.score = 0;
                Time.timeScale = 0f;
                break;
        }
    }
}
