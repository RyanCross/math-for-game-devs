using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class OptimizedTrigger : MonoBehaviour
{

    public Transform objTf; 
    [Range(0f, 4f)]
    public float radius = 1f;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        // Performance Optimization For Threshold Checks:
        // Square roots are a bit more expensive than multiplication or addition/subtraction operations.
        // If you are performing a lot of distance checks, which uses pythag theorem and thus involves a square root operation, you may want to optimize if you can
        // Note that this only works for 


        // A practical example would be:
        // Distance checks in a for loop over many objects in an update call, this is when it matters. Don't microptomize or it will make your code unreadable
        // Do NOT microoptimize every square root operation as it will make your code hard to read
        Vector2 objPos = objTf.position;
        Vector2 origin = transform.position; //same as this.transform.position or gameObject.position
        Vector2 disp = objPos - origin; // displacement vector from origin to objPos

        float distance = Mathf.Sqrt(disp.x * disp.x + disp.y * disp.y); // Optimization Tip: In some cases Mathf.Pow( disp.x, 2) is way slower, so we can also optimize away this for many distance checks case
        // unity's built in helper for the above: .sqMagnitude

        float distanceSq = disp.x * disp.x + disp.y * disp.y; // we can use this instead of distance to check a threshold IF we square the radius. (thus giving us the radius vector length squared)
        // note this only works for checking thresholds (< or > than something), if you need check actual distance you need to do the square root operation
        // desmos.com/calculator extremely useful for graphing stuff 

        bool isInside = distanceSq < radius * radius;
        Handles.color = isInside ? Color.green : Color.red;
        Handles.DrawWireDisc(origin, Vector3.forward, radius);
    }
#endif
}
