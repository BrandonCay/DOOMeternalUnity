using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    int health;
    [SerializeField] Health healthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
    public void takeDamage(int dmg)
    {
        Debug.Log("EN,DMG");
        health -= dmg;
        Debug.Log("HEALTH: " + health.ToString());
        healthBar.setHealth(health);
    }
}
