using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Functions1
{
    static public class PolarUtils
    {
        public static Vector2 CartessianToPolar(this Vector2 vector)
        {
            return new Vector2
                (
                Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y),
                Mathf.Atan2(vector.y, vector.x)
                );
        }

        public static Vector2 PolarToCartessian(this Vector2 vector)
        {
            return new Vector2
                (
                vector.x * Mathf.Cos(vector.y),
                vector.x * Mathf.Sin(vector.y)
                );
        }
    }
}

