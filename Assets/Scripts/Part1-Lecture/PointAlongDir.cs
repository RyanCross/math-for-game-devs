using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAlongDir : MonoBehaviour
{
    // One of the most useful things about direction is that we can very explicitly position things a fixed distance along that direction line.

    public Transform aTf;
    public Transform bTf;

    [Range(0f, 10f)]
    public float offset = 1f;

    [SerializeField] Vector2 aToB; // to-from to get this, so b-a
    [SerializeField] Vector2 aToBDir;
    [SerializeField] Vector2 pointAlongDir;
    [SerializeField] Vector2 midPoint;

    private void OnDrawGizmos()
    {
        Vector2 a = aTf.position;
        Vector2 b = bTf.position;

        aToB = b - a;
        aToBDir = aToB.normalized;
        Gizmos.DrawLine(a, a + aToBDir);

        pointAlongDir = aToBDir * offset;
        midPoint = aToB / 2;

        // remember the addition of the "a" vector is so that these spheres appear visually between the two vectors a and b, but isn't needed for the actual purpose of getting the midpoint or pointAlongDir vectors
        Gizmos.DrawSphere(a + pointAlongDir, .1f); 
        Gizmos.DrawSphere(a + midPoint, .1f);

    }
}
