using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

// detect the marker then play the audio
public class ContentManager : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour trackableBehaviour;
    public AudioSource audioSource;
    private bool intro_played = false;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectsWithTag("AudioManager")[0].GetComponent<AudioManager>();
        trackableBehaviour = GetComponent<TrackableBehaviour>();

        if (trackableBehaviour)
        {
            trackableBehaviour.RegisterTrackableEventHandler(this);
        }

        // Find AudioSource if not assigned
        if (audioSource == null)
        {
            if(audioManager.currentAudioSource) {
                audioManager.stopCurrentAudioSource();
            }
            audioManager.GetComponent<AudioManager>().currentAudioSource = audioSource;
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED)
        {
            // Marker detected or tracked, play audio
            if(audioManager.currentAudioSource) {
                    audioManager.stopCurrentAudioSource();
            }
            PlayAudio();
        }
        else
        {
            // Marker lost, stop or pause audio (if needed)
            audioSource.Stop(); // You might want to stop the audio when the marker is not detected
        }
    }

    void PlayAudio()
    {
        if (audioSource != null)
        {
            if (!audioSource.isPlaying && !intro_played)
            {
                audioSource.Play(); // Play the audio if it's not already playing
                intro_played = true;
            }
        }
        else
        {
            Debug.LogError("AudioSource not assigned!");
        }
    }
}
