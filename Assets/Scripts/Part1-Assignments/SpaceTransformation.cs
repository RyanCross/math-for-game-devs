using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTransformation : MonoBehaviour
{

    public Transform pt;
    public Transform origin;

    [SerializeField] Vector3 ptWorldPos;
    [SerializeField] Vector3 ptInLocalSpaceOfThisGameObj; // our goal for world -> local space transformation
    [SerializeField] Vector3 ptInLocalSpaceOfThisGameObjManual;
    [SerializeField] Vector3 originLocalSpace;
    [SerializeField] Vector3 ptBackToWorldSpace;
    [SerializeField] Vector3 ptBackToWorldSpaceManual;

    private void OnDrawGizmosSelected()
    {
        ptWorldPos = pt.position;
        ptInLocalSpaceOfThisGameObj = this.transform.InverseTransformPoint(pt.position);
        ptInLocalSpaceOfThisGameObjManual = WorldToLocalSpace(pt);
        originLocalSpace = WorldToLocalSpace(origin);
        ptBackToWorldSpace = this.transform.TransformPoint(ptInLocalSpaceOfThisGameObj);
        ptBackToWorldSpaceManual = LocalToWorldSpace(ptInLocalSpaceOfThisGameObj);
     
        Debug.DrawLine(Vector3.zero, ptInLocalSpaceOfThisGameObj);
    }

    // Transforms a vector to the local space of the object this script is attached to
    public Vector3 WorldToLocalSpace(Transform ptToTransform)
    {
        // get the normalized direction vectors of the axis of game object
        Vector3 currentXAxisDir = gameObject.transform.right; // normalized vector of the red axis in world space
        Gizmos.color = Color.red;
        Gizmos.DrawLine(gameObject.transform.position, gameObject.transform.position + currentXAxisDir);

        Vector3 currentYAxisDir = gameObject.transform.up; // normalized vector of the green axis in world space
        Gizmos.color = Color.green;
        Gizmos.DrawLine(gameObject.transform.position, gameObject.transform.position + currentYAxisDir);

        // project the displacement vector gameObjectPos -> ptPos onto the game objects axis using dot product
        float scalarProjectionX = Vector3.Dot(currentXAxisDir, ptToTransform.position - gameObject.transform.position); 
        float scalarProjectionY = Vector3.Dot(currentYAxisDir, ptToTransform.position - gameObject.transform.position);

        return new Vector3(scalarProjectionX, scalarProjectionY);
    }

    public Vector3 LocalToWorldSpace(Vector3 ptToTransform)
    {
        // I think now we must approach this from the perspective of being in gameobjects local space
        // meaning we need the direction vector of the origin's red & green axis in local space
        // TODO: get these manually
        Vector3 originXAxisDirLocal = this.transform.InverseTransformDirection(Vector3.right); 
        Vector3 originYAxisDirLocal = this.transform.InverseTransformDirection(Vector3.up);
        Debug.Log(originXAxisDirLocal); // might be good to serialize this and see
        Debug.Log(originYAxisDirLocal);

        float scalarProjectionX = Vector3.Dot(originXAxisDirLocal, ptToTransform - originLocalSpace);
        float scalarProjectionY = Vector3.Dot(originYAxisDirLocal, ptToTransform - originLocalSpace);

       // Gizmos.color = Color.yellow;
      //  Gizmos.DrawLine(Vector3.zero, ptBackToWorldSpace);
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(Vector3.zero, ptBackToWorldSpaceManual); //note the -, equivalent of originLocalSpace -> ptToTransform
        
        // floating point imprecision is masking how close I was to the answer: to - from (ptToTransform - originLocalSpace) results in the direct opposite vector.
        // the y component of pt back to world space and pt back to world space manual are both extremely small and approximate to 0.
        // The vector that needs to be projected on origins local space axis is ptToTransform -> originLocalSpace, why? Why does the inverse vector in local space get me origin -> pt in world space? Because I was doing shit WRONG transformed 

        // and the origin in local space


        return new Vector3(scalarProjectionX, scalarProjectionY);
    }
   
}
