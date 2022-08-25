using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Functions1
{
    public class ArchimedesSpiral : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float thiknessGain;


        private Vector2 polarCoords = Vector2.zero;
        private void Update()
        {
            //Theta -> Independent Variable
            polarCoords.y += Time.deltaTime;
            //Radio -> Dependent Variable
            polarCoords.x = polarCoords.y * speed;

            transform.localPosition = polarCoords.PolarToCartessian();
        }
    }
}
