using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Serialization;

public class DoubleHelix : MonoBehaviour
{
    [SerializeField] private Transform object2; //Second object that follows
    [SerializeField] [Range(0, 10)] private float speed;
    [SerializeField] private int xAmplitude; //Separation between both helix
    private float _angle;
    private Transform _object; //First object

    private void Start()
    {
        _object = GetComponent<Transform>();
    }

    private Vector3 _localPosition = Vector3.zero; //Object 1 Position
    
    private Vector3 _localPosition2 = Vector3.zero; //Object 2 Position
    private void Update()
    {
        _angle += speed * Time.deltaTime; //Angle transformation from speed
        
        _localPosition = _object.localPosition; //Set positions
        _localPosition2 = object2.localPosition;
        
        
        _localPosition.Set(Mathf.Cos(_angle), Mathf.Sin(_angle), _angle); 
        _localPosition2.Set(Mathf.Cos(_angle), Mathf.Sin(_angle), _angle+xAmplitude); 

        _object.localPosition = _localPosition;
        object2.localPosition = _localPosition2;
        
    }
}
