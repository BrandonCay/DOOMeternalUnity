using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    const int WEAP_CNT=2;
    int currWeapon;
    [SerializeField] GameObject[] weapons = new GameObject[WEAP_CNT];
    
    void Awake()
    {
        currWeapon = 0;
        weapons[0].SetActive(true);
    }
    void Update()
    {

        if (Input.mouseScrollDelta.y > 0.1f)
        {
            switchWeap(1);
        }else if(Input.mouseScrollDelta.y < -0.1f)
        {
            switchWeap(-1);
        }

    }

    void switchWeap(int sign)
    {
        weapons[currWeapon].SetActive(false);
        currWeapon = (currWeapon + 1 * sign + WEAP_CNT) % WEAP_CNT; //calculate next weapon in a circular array
        Debug.Log("SIGN: " + sign.ToString() + "NEXT WEAP: " + currWeapon.ToString());
        weapons[currWeapon].SetActive(true);
    }

}
