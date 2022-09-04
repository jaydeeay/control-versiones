using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class AntiGravityControl : MonoBehaviour
{
    private const float DRAG_STOP = 5000;
    [SerializeField] private ParticleSystem particleSystem;
    private Rigidbody rigidbody ;
    private float startDrag = 0;
    private Vector3 startVelocity;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        startDrag = rigidbody.drag;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            startVelocity = rigidbody.velocity;
            rigidbody.drag = DRAG_STOP;
            particleSystem.Play();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rigidbody.drag = 0;
            rigidbody.velocity = startVelocity;
            particleSystem.Stop();
        }
    }
}
