using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Torus : MonoBehaviour
{
    [SerializeField] [Range(0, 100)] private float speed;

    [SerializeField] private float radius1;
    [SerializeField] private float radius2;
    [SerializeField] private float insideLaps; 
    private Transform _object;
    private float _angle;
    private void Start()
    {
        _object = GetComponent<Transform>();
    }
    
    Vector3 _localPosition = Vector3.zero;
    private void Update()
    {
        _angle += speed * Time.deltaTime * Mathf.Deg2Rad;

        _localPosition.Set((radius1 + (radius2 * Mathf.Cos(insideLaps * _angle))) * Mathf.Cos(_angle), (radius1 + (radius2 * Mathf.Cos(insideLaps * _angle))) * Mathf.Sin(_angle), radius2 * Mathf.Sin(insideLaps * _angle));
        
        _object.localPosition = _localPosition;
        
    }
}
