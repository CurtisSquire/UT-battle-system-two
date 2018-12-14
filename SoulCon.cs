using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulCon : MonoBehaviour
{
    //creates velosity speed and rigidbody variables. 
    private Vector2 Vel;
    public static float speed = 2;
    private Rigidbody2D rb;
    public GameObject Bullet;
    public Transform SpawnBullet;
    public float rateOfFire;
    private float NextShot;
    Vector3 myStartPosition;
    // Update is called once per frame

    void Start()
    {
        //attaches rigidbody to the variable called rb. 
        rb = GetComponent<Rigidbody2D>();
        myStartPosition = transform.position;

    }
    void Update()
    {
        //takes input from the player.  
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //uses input from player and speed to set vel(velosity). 
        Vel = input.normalized * speed;
        //if the player presses the fire one button (that I have set for space bar) it will spawn a bullet into the scene. 
        //the player can only fire a bullet every half seacond because I set rateOfFire to 0.50f in unity. 
        if (Input.GetButton("Fire1") && Time.time > NextShot && TurnState.AttackMode == true)
        {
            NextShot = Time.time + rateOfFire; 
            Instantiate(Bullet, SpawnBullet.position, SpawnBullet.rotation);
        }
    }

    void FixedUpdate()
    {
        //moves the player based on imput. 
        rb.MovePosition(rb.position + Vel * Time.fixedDeltaTime);
    }
    //creates a function used to reset the Position of the player. 
    public void ResetSoul()
    {
        transform.position = myStartPosition;
    }
}
