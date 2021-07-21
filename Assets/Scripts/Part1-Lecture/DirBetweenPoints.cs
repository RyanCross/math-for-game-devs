using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirBetweenPoints : MonoBehaviour
{
    // Two get the direction between two pts ( the tips of two vectors), a and b, you the need vector a->b, or b->a, then you normalize

    // It feels kind of backwards but to get the vector a->b you need to do b - a (to - from), and vice versa for b->a you need to do (a - b)
    public Transform aTf;
    public Transform bTf;

    private void OnDrawGizmos()
    {
        Vector2 a = aTf.position;
        Vector2 b = bTf.position;

        Vector2 aToB = b - a;
        Vector2 aToBDir = aToB.normalized;
        Gizmos.DrawLine(Vector2.zero, aToBDir); // <- This gives you the direction vector between two pts
        Gizmos.DrawLine(a, a + aToBDir); // the addition of a here creates an offset which is purely for visualization, such that the vector (a + aToBDir) is drawn from a instead of the origin
    }
}
