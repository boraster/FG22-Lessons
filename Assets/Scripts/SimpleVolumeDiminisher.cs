using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleVolumeDiminisher : MonoBehaviour
{
    [SerializeField] private float volumeRolloffRate = 0.5f;
    private float volume;
    private AudioSource source;
    

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            source.volume -= source.volume * volumeRolloffRate * Time.deltaTime;
        }
    }
}
