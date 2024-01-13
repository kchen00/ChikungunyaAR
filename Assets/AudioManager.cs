using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource currentAudioSource;

    public void setAudioSource(AudioSource newAudio)
    {
        // check if there is audio source or not
        // if yes, then stop the audio
        stopAudio();

        // then set the current audio source to the new audio
        currentAudioSource = newAudio;
    }

    public void stopAudio()
    {
        // check if there is audio source or not
        // if yes, then stop the audio
        if (currentAudioSource)
        {
            currentAudioSource.Stop();
        }
    }
}
