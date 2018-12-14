using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour {


    //onCollision used to detect collition with SpeedPowerUp gameObject. 
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("SpeedPower"))
        {
            //increases speed var in SoulCon script and destroyes the Speed power up game object. 
            Destroy(c.gameObject);
            SoulCon.speed += 2;
        }
    }
}
