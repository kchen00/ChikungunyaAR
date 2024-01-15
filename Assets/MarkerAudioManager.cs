﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

// detect the marker then play the audio
public class MarkerAudioManager : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour trackableBehaviour;
    public AudioSource audioSource;
    private AudioManager audioManager;
    private GameObject model;
    void Start()
    {
        audioManager = GameObject.FindGameObjectsWithTag("AudioManager")[0].GetComponent<AudioManager>();
        trackableBehaviour = GetComponent<TrackableBehaviour>();

        if (trackableBehaviour)
        {
            trackableBehaviour.RegisterTrackableEventHandler(this);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED)
        {
            if (audioSource)
            {
                if (!audioSource.isPlaying)
                {
                    playAudio();
                }
            }
            else
            {
                Debug.LogError("AudioSource not assigned!");
            }

        }
        else
        {
            // Marker lost, stop or pause audio (if needed)
            // stop the audio when the marker is not detected
            audioManager.stopAudio();
            if(model) {
                model.SetActive(false);

            }

        }
    }

    private void playAudio()
    {
        // set the audio source in audio manager to the audio source of this object
        audioManager.setAudioSource(audioSource);
        // playe the audio 
        audioSource.Play();
    }

    public void setModel(GameObject childModel) {
        model = childModel;
    }
}
