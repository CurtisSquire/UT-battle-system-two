using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class RandomEncounters : MonoBehaviour {
    //creates variables 
    float randomNum = 0;
    float Chance = 15;
	void Start ()
    {
        //sets a random number on the ground tile the script is attached to to any float number between 1 and 100. 
        randomNum = Random.Range(0, 100); 

	}

    //detects collition. 
    void OnTriggerEnter2D(Collider2D c)
    {
        //if it collides with "HumanPlayer" taged object it cheaks if the random number is lower then the probability that I have set in the chance variable(15%) 
        if (c.gameObject.CompareTag("HumanPlayer"))
        {
             
            if (randomNum <= Chance)
            {
                SceneManager.LoadScene("Battle System one"); 
            }
            //if it is not it gets a new rondom number 
            else
            {
                randomNum = Random.Range(0, 100); 
            }
        }
        
    }
}
