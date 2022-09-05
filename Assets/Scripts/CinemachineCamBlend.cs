using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CinemachineCamBlend : MonoBehaviour
{
    public CinemachineVirtualCamera[] cameras;
    [SerializeField] private int index = 0;
    [SerializeField] private int priorityValue = 10;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].Priority = priorityValue;

                if (index == i)
                {
                    cameras[index].Priority = priorityValue + 1;
                }
            }

            index++;
            index %= cameras.Length;
        }
    }
}