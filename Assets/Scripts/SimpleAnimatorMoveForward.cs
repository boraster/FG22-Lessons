using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimpleAnimatorMoveForward : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    private float velocity = 1.0f;
    [SerializeField]
    private float animSpeedMultiplier = 2.0f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    

    private void Update()
    {
        transform.Translate(Vector3.forward * (velocity * Time.deltaTime));
        anim.speed = animSpeedMultiplier;
    }
}
