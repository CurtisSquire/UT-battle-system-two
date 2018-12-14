using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayerMove : MonoBehaviour
{
    //sets up variables
    private Vector2 Vel;
    public float speed = 2;
    private Rigidbody2D rb;
    private Camera mainCamera;
    Vector3 myPositionBeforeBattle; 

    void Start()
    {
        //attaches rigidbody to the variable called rb. 
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //takes input from the player.  
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //uses input from player and speed to set vel(velosity). 
        Vel = input.normalized * speed;
        myPositionBeforeBattle = transform.position; 
    }
    void FixedUpdate()
    {
        //moves the player based on imput. 
        rb.MovePosition(rb.position + Vel * Time.fixedDeltaTime);
    }
    
}