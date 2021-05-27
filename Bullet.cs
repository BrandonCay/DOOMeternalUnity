using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] const float speed = 50f, exprTime = 10f; 
    int dmg=10;
    Vector3 initVel;
    
    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        initVel = Vector3.forward;
        Destroy(gameObject, exprTime);
    }
    private void Update()
    {

        transform.Translate(initVel *  Time.deltaTime * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        enemy e = other.transform.GetComponent<enemy>();
        Debug.Log("BULLET COLLIDE: " + other.ToString());
        if (e != null)
            e.takeDamage(dmg);
        Destroy(gameObject);
    }


}
