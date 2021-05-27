using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperShotgun : MonoBehaviour
{
    LayerMask enemy;
    RaycastHit hit;
    const int dmg = 50;
    private void Start()
    {
        enemy = LayerMask.GetMask("enemy");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }

    void shoot()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 20f, enemy))
        {
            hit.transform.GetComponent<enemy>().takeDamage(dmg);
        }
    }
}
