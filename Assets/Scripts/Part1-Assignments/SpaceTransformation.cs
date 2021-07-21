using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTransformation : MonoBehaviour
{

    public Transform pt;
   
    [SerializeField] Vector3 ptRelativeToThisObj;
    [SerializeField] Vector3 currentXAxisDir; // Red
    [SerializeField] Vector3 currentYAxisDir; // Green
    [SerializeField] float scalarProjectionX; // scalar projection of distance vector: someGameObj to pt, along gameObj X axis dir vector
    [SerializeField] float scalarProjectionY;

    [SerializeField] Vector3 someObjToPointDisplacement;

    private void OnDrawGizmos()
    {
        ptRelativeToThisObj = this.transform.InverseTransformPoint(pt.position);
        transformWorldToLocal();


        currentXAxisDir = gameObject.transform.right;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(gameObject.transform.position, gameObject.transform.position + currentXAxisDir);

        currentYAxisDir = gameObject.transform.up;
        Gizmos.color = Color.green;
        Gizmos.DrawLine(gameObject.transform.position, gameObject.transform.position + currentYAxisDir);

        scalarProjectionX = Vector3.Dot(currentXAxisDir, pt.position - gameObject.transform.position); //frick it really just works
        scalarProjectionY = Vector3.Dot(currentXAxisDir, pt.position - gameObject.transform.position);
        // tomorrow - write down why this works
        // add visualizers to help. maybe extend gizmo lines to infinity?
        // test if displacement made a var does it still work?


    }

    public Vector3 transformWorldToLocal()
    {
        // considering no rotation, the local space position of pt relative to this game object is the displacement vector from game obj to pt
        someObjToPointDisplacement = pt.position - gameObject.transform.position;

        return Vector3.up;
    }
}
