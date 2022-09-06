using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SinWave : MonoBehaviour
{
    [SerializeField] [Range(0, 100)] private float speed;

    [SerializeField] private float radius;
    [SerializeField] private float AngularSpeed; 
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
        float x = (radius * Mathf.Cos(_angle));
        float y = (radius * Mathf.Sin(_angle));
        float z = Mathf.Sin(AngularSpeed * _angle);

        _localPosition.Set(x,y,z);
        
        _object.localPosition = _localPosition;
        
    }
}
