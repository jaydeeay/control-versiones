using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    [SerializeField] private float attackDuration;
    [SerializeField] private GameObject collider;

    void DisableCollider()
    {
        collider.SetActive(false);
    }


    private void Awake()
    {
            DisableCollider();
    }

    void Update()
    {
        if (!collider.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                collider.SetActive(true);
                Invoke(nameof(DisableCollider),attackDuration);
            }
        }
    }
}
