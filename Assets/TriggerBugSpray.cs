﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TriggerBugSpray : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject sprayParticles;
    public Animator mosquitoAnimator;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if(sprayParticles) {
            sprayParticles.SetActive(true);
            mosquitoAnimator.SetTrigger("kill_mosquito");
        }
        
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        if(sprayParticles) {
            sprayParticles.SetActive(false);
            mosquitoAnimator.ResetTrigger("kill_mosquito");
        }

    }
}
