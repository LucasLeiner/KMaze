using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    public AudioSource self;
    public Slider musicVolume;

    // Start is called before the first frame update
    void Start()
    {
        musicVolume.value = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        self.volume = musicVolume.value;
        if (CherryManager.onCherry)
        {
            self.pitch = 1.5f;
        }
        else
        {
            self.pitch = 1f;
        }
        
    }
}
