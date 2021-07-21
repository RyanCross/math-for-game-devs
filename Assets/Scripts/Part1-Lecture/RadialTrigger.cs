using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class RadialTrigger : MonoBehaviour
{

    public Transform objTf; // tf of the thing thats entering our trigger;
    [Range(0f, 4f)]
    public float radius = 1f;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Vector2 objPos = objTf.position;
        Vector2 origin = transform.position; //same as this.transform.position or gameObject.position
        // if you want to the editor only Handles lib, you need to compile out the lib and code or you'll get build errors in an actual build

        float dist = Vector2.Distance(objPos, origin);
        // the radius here is the length of the "radius vector", which is the vector from the center of the disc to any point on its circumfrence
        bool isInside = dist < radius;
        Handles.color = isInside ? Color.green : Color.red;
        Handles.DrawWireDisc(origin, Vector3.forward, radius);
    }
#endif
}
