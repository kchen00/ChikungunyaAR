using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class button : MonoBehaviour, IVirtualButtonEventHandler
{
    public AudioSource audioSource;
    private AudioManager audioManager;


    public GameObject model;  // object to manage, can activate or deactivate the object with the press of button
    public bool despawn = false; // despawn object if button is not pressed
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectsWithTag("AudioManager")[0].GetComponent<AudioManager>();
        GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play_audio() {
        if (audioSource != null)
        {
            if (!audioSource.isPlaying)
            {
                if(audioManager.currentAudioSource) {
                    audioManager.stopCurrentAudioSource();
                }
                audioManager.GetComponent<AudioManager>().currentAudioSource = audioSource;
                audioSource.Play(); // Play the audio if it's not already playing
            }
        }
        else
        {
            Debug.LogError("AudioSource not assigned!");
        }
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        if(model) {
            model.SetActive(true);

        }
        play_audio();
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb) {
        if (model && despawn) {
            model.SetActive(false);

        }
    }
}
