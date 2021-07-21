using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTrigger : MonoBehaviour
{
    // Detect if player is looking toward the trigger.
    // true if looking at, false if not
    // Look at trigger should also have a threshold from 0-1
    // if threshold is 1 = very strict, need to look exactly at the trigger (likely impossible due to fp imprecision)
    // 0 = perpendicular or closer and the player is "looking at" the trigger
    // < 0 false

    [Range (0,1)]
    public float lookTolerance; 
    public Transform playerTf;
    // we can represent the players current look direction with a normalized vector towards some pt in space
    public Transform lookingAt;
    public Transform lookAtTriggerPt;

    Vector2 playerLookDir;
    [SerializeField] float lookDirLength;
    [SerializeField] float curLookDirExactLookDirCloseness;

    private void OnDrawGizmos()
    {
        Vector2 playerPos = playerTf.position;
        Vector2 curLookPos = lookingAt.position; // the point the player is currently "looking at"
        Vector2 lookAtTriggerPos = lookAtTriggerPt.position;

        Vector2 playerCurrentLookPtDisplacement = curLookPos - playerPos;
        Vector2 playerLookAtTriggerPtDisplacement = lookAtTriggerPos - playerPos;

        // by normalizing both of these, we can get the "closeness" relationship of these two vectors (how close they are to pointing in the same dir)
        Vector2 currentLookDir = playerCurrentLookPtDisplacement.normalized;
        Vector2 exactLookDir = playerLookAtTriggerPtDisplacement.normalized;

        Gizmos.DrawLine(playerPos, playerPos + playerCurrentLookPtDisplacement.normalized);
        Gizmos.DrawLine(playerPos, playerPos + playerLookAtTriggerPtDisplacement.normalized);


        //represents how close player is to looking exactly at lookAtTrigger
        // or in another words, how much does the curLookDir differ from exactLookDir, where exactLookDir is the vector from playerPos to lookAtTrigger
        // 1 = same exact dir, 0 = perpindicular, <0 = facing away, -1 exact opposite dir
        curLookDirExactLookDirCloseness = Vector2.Dot(exactLookDir, currentLookDir);

        if (curLookDirExactLookDirCloseness >= lookTolerance)
        {
            Gizmos.color = Color.green; // Looking at it!

        }
        else
        {
            Gizmos.color = Color.red; // Not looking at it.
        }

        Gizmos.DrawSphere(lookAtTriggerPos, 1);


        //Gizmos.DrawLine(playerPos, playerPos + Vector2.up);
    }
}
