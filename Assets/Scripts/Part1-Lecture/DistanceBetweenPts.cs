using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceBetweenPts : MonoBehaviour
{
    // When we say distance, we are asking how long is the vector that is the displacement (distance) between two points
    // To calculate distance manually, the equation length(b-a) or length(a-b) will result the in the displacement vector, where a and b are the two vectors representing your points

    // First subtract a-b from each other to get the difference vector
    // Then check the length of that difference vector

    public Transform ptA;
    public Transform ptB;

    [SerializeField] float distance;
    [SerializeField] float distanceManualCalc;
    [SerializeField] float distanceManualCalcM2; 


    private void OnDrawGizmos()
    {
        // Built in helper
        distance = Vector2.Distance(ptA.position, ptB.position);

        // Manual
        // Subtract individual x,y components to get the difference vector components
        // calculate length of difference vector sqrt(x^2 + y^2)
        distanceManualCalc = Mathf.Sqrt(Mathf.Pow(ptA.position.x - ptB.position.x, 2) + Mathf.Pow(ptA.position.y - ptB.position.y, 2));
        
        // same calcuation as above
        distanceManualCalcM2 = (ptA.position - ptB.position).magnitude; // might be useful to write it this way in cases where you want to do this Vector math but the target is not a distance value.

        Gizmos.DrawLine(ptA.position, ptB.position);
    }


}
