using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{

    /*
     * Responsible for looking around, and other things that pertain to the player's sight
     */
    //Attached to camera object
    [SerializeField] private float mouseY, mouseX, rotationX=0, sensitivity = 10000f;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform Gun;
    // Start is called before the first frame update
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        rotationX -= mouseY; //rotate around x axis (i.e. up and down); subtract to look up
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); //prevent camera from rotating more than 90

        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);  //rotate camera upwrds (around x axis)
        Player.Rotate(Vector3.up * mouseX);//rotate character (around y axis)
    }
}
