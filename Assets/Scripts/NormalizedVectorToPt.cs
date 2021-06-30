using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalizedVectorToPt : MonoBehaviour
{

    public Transform pt;  
    [SerializeField] Vector2 dirToPt; // direction is represented as a vector with length 1 (aka a unit or normalized vector)
    [SerializeField] Vector2 dirToPtManualCalc;

    // only called in the editor
    void OnDrawGizmos() {
        dirToPt = pt.position.normalized;
        Gizmos.DrawLine(Vector2.zero, dirToPt);

        // Manual
        // You can get the normalized vector of any vector by dividing the vector by it's length
        // really what this is doing is dividing each component of the vector by the magnitude, which results in your unit vector values
        // pt.position.x / magnitude & pt.position.y / magnitude
        dirToPtManualCalc = pt.position / pt.position.magnitude; // <- there is a degenerate case to handle here, if magnitude is zero you are dividing by zero, your trying to figure out the direction of a vector that doesn't have a direction.

        // Anytime you see a division operator, you should think about whether or not there is a case where the denominator can be zero, if it is, then you need to decide how to handle that case.
    }
}
