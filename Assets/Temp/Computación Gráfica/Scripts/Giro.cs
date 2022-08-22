using System;
using UnityEngine;

public class Giro : MonoBehaviour
{
    [SerializeField]
    private float degreesPerSecond = 5f;
    private Transform _transform;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("Awake");
        _transform = transform;
    }

    private void Start()
    {
            Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
        _transform.Rotate(0f, degreesPerSecond * Time.deltaTime, 0f);
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }
}
