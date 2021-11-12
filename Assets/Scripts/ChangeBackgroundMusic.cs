using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackgroundMusic : MonoBehaviour
{
    public AudioClip[] audioClips;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();

        audioSource.clip = audioClips[0];
        audioSource.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = audioClips[1];
            audioSource.Play(); 
        }
        
    }
}
