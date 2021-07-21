using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RadialTriggerA1 : MonoBehaviour
{
    [Range (0, 10)]
    public float radius;
    public Transform oTf;

    private void OnDrawGizmos()
    {
        if (oTf.position.sqrMagnitude < radius * radius) // performant version, threshold is length sq of the oTf pos vector against the radius sq
        {
            Handles.color = Color.green;
        }
        else
        {
            Handles.color = Color.red;
        }
        
        Handles.DrawWireDisc(transform.position, Vector3.forward, radius);
    }
}
