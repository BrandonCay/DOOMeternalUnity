using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject template;//bullet template
    // Update is called once per frame
    float fireDelay = .10f, nextFire=0f;
    void Update()
    {
        
        if (Input.GetMouseButton(0))//left click primary fire
        {
            if (Time.time > nextFire)
            {
                Instantiate(template, template.transform.position, template.transform.rotation).SetActive(true);
                nextFire = Time.time + fireDelay;
            }
        }
    }
}
