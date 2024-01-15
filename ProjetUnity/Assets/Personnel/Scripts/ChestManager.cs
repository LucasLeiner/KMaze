using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class ChestManager : MonoBehaviour
{
    public GameObject MenuChest;
    public AudioSource audioFin;
    private AudioSource[] allAudioSources;
    public GameObject MenuFin;
    public Animator animator;
    private bool onChest;
    public Transform ChestPosition;
    // Start is called before the first frame update
    void Start()
    {
        onChest = false;
        MenuFin.SetActive(false);
        MenuChest.SetActive(false);
    }
    void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreManager.score >= 20)
        {
            gameObject.transform.position = ChestPosition.position;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            onChest=true;
            MenuChest.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        onChest = false;
        MenuChest.SetActive(false);
    }

    public void Finish()
    {
        if(onChest && KeyManager.keyTaken)
        {
            MenuChest.SetActive(false);
            if (scoreManager.score > scoreManager.highScore)
            {
                scoreManager.highScore = scoreManager.score;
                PlayerPrefs.SetInt("HighScore", scoreManager.highScore);
            }
            scoreManager.score = 0;
            StartCoroutine("Fin");
        }
    }

    IEnumerator Fin()
    {
        animator.SetBool("Finished", true);
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
        MenuFin.SetActive(true);
        StopAllAudio();
        audioFin.Play();
    }
}
