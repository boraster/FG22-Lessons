using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimBlend : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    private float horizontal = 0.0f;
    [SerializeField]
    private float vertical = 0.0f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (horizontal != 0)
        {
            anim.SetFloat("TurningVelocity", horizontal);
        }

        if (vertical != 0)
        {
            anim.SetFloat("Velocity", vertical);
        }
    }
}
