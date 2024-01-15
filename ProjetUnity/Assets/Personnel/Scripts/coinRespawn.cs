using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinRespawn : MonoBehaviour
{
    public GameObject coinPrefab;
    public float rotationSpeed = 85f;
    private bool isVisible;
    public GameObject spawnPoints;
    private Transform spawnTransforms;
    public static bool cherrySpawn;
    public AudioSource audioSourceSelf;
    public Slider sliderVolumeSfx;

    private void Start()
    {
        sliderVolumeSfx.value = 0.1f;
        cherrySpawn = false;
        isVisible = true;
        spawnTransforms = spawnPoints.transform;
        teleportCoin();
    }

    private void teleportCoin()
    {
        Transform child = spawnTransforms.GetChild(Random.Range(0, spawnTransforms.childCount));
        gameObject.transform.position = child.position;
    }

    void Update(){
        if(!isVisible) return;

        audioSourceSelf.volume = sliderVolumeSfx.value;

        gameObject.transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);
    }
    
    private void OnBecameVisible(){
        isVisible = true;
    }
    private void OnBecameInvisible(){
        isVisible = false;
    }

    private void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            scoreManager.score += 1;
            audioSourceSelf.Play();
            teleportCoin();
            if(scoreManager.score > 0 && scoreManager.score%5 == 0)
            {
                cherrySpawn = true;
            }
        }
    }


}
