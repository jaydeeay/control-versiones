using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MagicAttackController : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private ParticleSystem particles;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (!particles.isEmitting)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Attack");
                particles.Play();
            }
        }
    }
}
