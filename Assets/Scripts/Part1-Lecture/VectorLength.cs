using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorLength : MonoBehaviour {
    public Transform pt;

    // Length
    // For Scalars (aka 1D vectors):
    // EX: 5, -5
    // Length/Magnitude = abs(x)
    public float exampleScalar;
    [SerializeField] float exampleLength1D;

    // For 2D vectors we can apply pythags theorem (x^2 + y^2 = c^2, c is the length)
    [SerializeField] float length2D;
    [SerializeField] float length2DManual;

   void OnDrawGizmos() {
        exampleLength1D = Mathf.Abs(exampleScalar);

        // should be the same
        length2D = pt.position.magnitude;
        length2DManual = Mathf.Sqrt(Mathf.Pow(pt.position.x, 2) + Mathf.Pow(pt.position.y, 2));

        Gizmos.DrawLine(Vector2.zero, pt.position);
   }
}
