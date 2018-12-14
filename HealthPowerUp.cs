using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    private float RandomNumOne;

    void Start()
    {
        RandomNumOne = Random.Range(0.0f, 100.0f);    
    }

    //onCollision used to detect collition with HealthPowerUp gameObject. If collision is detected heath is increased. 
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("HealthPower"))
        {
            Destroy(c.gameObject);
            Health.life += 1; 
        }
    }
}
