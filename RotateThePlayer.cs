using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class RotateThePlayer : MonoBehaviour {
    //creates a method to useing a vector3 to look at the mouse. 
    void LookAtTheMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 directionToFace = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = directionToFace;
    }

    // Update is called once per frame
    void Update ()
    {
        //method called in update so it is called every frame 
        LookAtTheMouse(); 	
	}
}
