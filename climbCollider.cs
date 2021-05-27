using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climbCollider : MonoBehaviour
{
    /**
     * Use layer mask to isolate the climable objects
     */
    private void OnTriggerEnter(Collider other)
    {
        Movement.destination = other.transform.position;
        Movement.canClimb = true;
    }
    private void OnTriggerExit()
    {
        Movement.canClimb = false;
    }
}
