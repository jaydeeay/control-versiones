using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Serialization;

public class DoubleHelix : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] private float speed;
    [SerializeField] float separation; //needs to be the same as speed 
    private float _angle;
    private Transform _object; //First object

    private void Start()
    {
        _object = GetComponent<Transform>();
    }

    private Vector3 _localPosition = Vector3.zero; //Object Position
    
    private void Update()
    {
        _angle += speed * Time.deltaTime; //Angle transformation from speed
        
        _localPosition = _object.localPosition; //Set position
        
        
        _localPosition.Set(Mathf.Cos(_angle+separation), Mathf.Sin(_angle+separation), _angle);

        _object.localPosition = _localPosition;
        
    }
}
