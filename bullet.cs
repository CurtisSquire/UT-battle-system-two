using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public float speed = 1;
    //I put the bullets rigidbody in this variable in unity. 
    public Rigidbody2D rigbody; 
	
	// Update is called once per frame
	void Update ()
    {
        //causes the bullet to move up. 
        rigbody.velocity = (transform.up * speed); 
	}
    //cheaks for collision
    void OnTriggerEnter2D(Collider2D collision)
    {
        //cheaks if the object the bullet collided with is the enemy. if so it destroys itself and takes away enemy health. 
        //else if it collides with the BulletDestroyer it just destroys the bullet. 
       if (collision.gameObject.layer == LayerMask.NameToLayer("Boss"))
        {
            Destroy(gameObject);
            TurnState.EnemyHealth--; 
        }
       else if (collision.gameObject.layer == LayerMask.NameToLayer("BulletDestroyer"))
        {
            Destroy(gameObject); 
        }
    }
}
