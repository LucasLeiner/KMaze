using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour
{
    private bool restarted;

    public void Start()
    {
        restarted = false;
    }
    // Start is called before the first frame update
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        restarted = true;
        RestartManager.health = 4;
    }

    private void Update()
    {
        if (restarted)
        {
            Time.timeScale = 1f;
            restarted = false;
        }
    }
}
