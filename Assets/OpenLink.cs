using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class OpenLink : MonoBehaviour, IVirtualButtonEventHandler
{
    public string link;
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
        Debug.Log("button presse, opening link");
        Application.OpenURL(link);
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

    }
}

