using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDeactivator : MonoBehaviour
{
    private Camera mainCam;
    public Canvas welcomeCanvas;
    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Deactivator"))
        {
            welcomeCanvas.gameObject.SetActive(false);
        }
    }
}
