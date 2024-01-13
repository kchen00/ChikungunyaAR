using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;
using Vuforia;

public class ButtonAudio : MonoBehaviour, IVirtualButtonEventHandler
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

        if(model) {
            GameObject parentMarker = transform.parent.gameObject;
            MarkerAudioManager parentMarkerAudioManager = parentMarker.GetComponent<MarkerAudioManager>();
            parentMarkerAudioManager.setModel(model);
        }
              
    }

    public void playAudio()
    {
        if (audioSource != null)
        {
            // if audio is not playing and the marker is detected
            if (!audioSource.isPlaying)
            {
                // pass the audio source of this button to audio manager
                audioManager.setAudioSource(audioSource);

                // Play the audio if it's not already playing
                audioSource.Play();
            }
        }
        else
        {
            Debug.LogError("AudioSource not assigned!");
        }
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (model)
        {
            model.SetActive(true);

        }
        playAudio();
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        if (model && despawn)
        {
            model.SetActive(false);
        }
    }
}
