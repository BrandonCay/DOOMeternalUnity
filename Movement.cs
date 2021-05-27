using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    /**
     * Movenment Options:
     * XY axis run (no friction)
     * Double Jump (Z axis-motion)
     * Climb/Clamber when looking and close to edges
     * Dash (on ground + off ground)
     */

    // Start is called before the first frame update
    [SerializeField] const float maxRunSpeed = 10f, maxDashSpeed=maxRunSpeed *3, maxJumpH = 10f, gravityA = -14f;
    [SerializeField] float rightVelocity, forwardVelocity, upVelocity, dashSpeed = maxDashSpeed;
    [SerializeField] CharacterController controller;
    
    public static bool onGround, airJmp, canClimb, jumped;
    Vector3 velocity;
    public static Vector3 destination; //climb script uses destrination to teleport player
    public static int dashCnt = 2;
    const string forwardK = "w", rightK = "d", backK = "s", leftK = "a", jumpK = "space", dashK="left shift";
    //defines variables to hold input keys for actions. The variables allow me to quickly change keys for actions and allow players
    //to change keys if I add the feature to change controls. Input Manager may have an more efficient way to do this. I need to research this later 5/22/
    private void Awake()
    {
         upVelocity = 0f;
        controller = GetComponent<CharacterController>();
        onGround = false; airJmp = false;
       // Debug.unityLogger.logEnabled = false;
    }
    void Update() {
        rightVelocity = 0f; forwardVelocity = 0f;


        if (onGround) {
            dashCnt = 2; airJmp = true;
        }


            if (Input.GetKey(forwardK))
            {
                setForRun(1);
            }
            else if (Input.GetKey(backK))
            {
                setForRun(-1);
            }

            if (Input.GetKey(rightK))
            {
                setRightRun(1);
            }
            else if (Input.GetKey(leftK))
            {
                setRightRun(-1);
            }

            if (Input.GetKeyDown(jumpK))
            {
                if (onGround)
                {
                    onGround = false;
                    upVelocity = Mathf.Sqrt(maxJumpH * -2f * gravityA);

                }
                else if (airJmp)
                {
                    airJmp = false;
                    upVelocity = Mathf.Sqrt(maxJumpH * -2f * gravityA);
                }

            }
            else if (!onGround)
            {
                upVelocity = upVelocity + gravityA * Time.deltaTime;//gravita A is negative
            }
            else
            {
                upVelocity = 0f;
            }

            if (Input.GetKeyDown(dashK) && dashCnt > 0) //dash; if player is moving in a 1 direction, increase runSpeed by some factor in that direction
            {
                if (forwardVelocity > 0.1f || forwardVelocity < -0.1f)
                { //if moving in any direction 
                    forwardVelocity = dashSpeed / Time.deltaTime;
                }
                else if (rightVelocity > 0.1f || rightVelocity < -0.1f)
                {
                    rightVelocity = dashSpeed / Time.deltaTime;
                }

                --dashCnt;
            }


            velocity = (transform.forward * forwardVelocity + transform.right * rightVelocity + transform.up * upVelocity) * Time.deltaTime;
        if (!jumped && canClimb)
        {
            Debug.Log("DEST: " + destination.ToString());
            transform.position = destination + Vector3.up * 0.6f;//temporary solution
            //transform.Translate(); 5/26 need to do the math to place object exactly above the ledge in an easy fashion
            //need to use lerp to gradually move an object from point A to point B

        }
        else
        {
            controller.Move(velocity);
        }
    }

    void setRightRun(int sign)
    {
        rightVelocity = maxRunSpeed * sign;
        dashSpeed = maxDashSpeed * sign;
    }
    void setForRun(int sign)
    {
        forwardVelocity = maxRunSpeed * sign;
        dashSpeed = maxDashSpeed * sign;
    }

}
