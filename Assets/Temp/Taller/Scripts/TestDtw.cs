using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Animations.Rigging;
using Random = UnityEngine.Random;

public class TestDtw : MonoBehaviour
{
    public Transform target;
    public float speed;
    public Ease myEase = Ease.Linear;
    private Rigidbody rigo;
    private Renderer rendo;

    
    private void Start()
    {
        rigo = GetComponent<Rigidbody>();
        rendo = GetComponent<Renderer>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            DOTween.Sequence()
                .Append(transform.DOJump(target.position, 2, 3,1.5f).SetEase(myEase))
                .Join(transform.DOScale(2, speed))
                .Append(rendo.material.DOColor(Random.ColorHSV(), 1.5f).SetEase(Ease.InBounce)).OnComplete(Terminado);
        }
        
    }

    void Terminado()
    {
        Debug.Log("Ya pa");
    }
    private void OnDisable()
    {
        DOTween.KillAll(gameObject);
    }
}
