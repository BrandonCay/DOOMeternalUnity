using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCollider : MonoBehaviour
{
    //bug onTriggerEnter won't trigger after some 
    private void OnTriggerEnter()
    {

        Movement.onGround = true; 
    }
    private void OnTriggerExit()
    {
        Movement.onGround = false;
    }
}
