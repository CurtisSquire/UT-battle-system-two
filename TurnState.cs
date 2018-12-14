using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//i make sure to include scene management in this one so that I can use the win and lose scene screens. 
using UnityEngine.SceneManagement; 

public class TurnState : MonoBehaviour {
    //creats public game object variables that are placed into the script in unity. 
    public GameObject UIBattleMenu;
    public GameObject itemMenu;  
    public GameObject AttackBulletsOne;
    public GameObject AttackBulletsTwo;
    public GameObject AttackBulletsThree;
    //creates randomNum variable and sets it to 0 by defult 
    private int randomNum = 0;
    //creates a bool variable called AttackMode that is static so it can be used in other scripts if needed. 
    public static bool AttackMode; 
    //creates the whosTurn variable witch is used as a switch later in the game. 
    private Turns whosTurn;
    //static float called BattleTurn. 
    public static float BattleTurn;
    //creates timers for how long the enemy turn should last. 
    public float EnemyTurnTimer = 0;
    private float EnemyTurnDuration = 10.0f;
    //I place the Attack one, Attack Two and Attack Three game objects in here as they are all in change of different positions the enemy attack square can load in. 
    public Battle[] AttackOne;
    public Battle[] AttackTwo;
    public Battle[] AttackThree;
    //i place the Soul(Player heart) in this variable 
    public SoulCon mySoul;
    //creates a static flaot for the enemy health set to be 15 by and the beggining
    public static float EnemyHealth = 15.0f;

	public enum Turns
       
    { 
        //creates all members of Turns
        PLAYERTURN, 
        ENEMYTURN, 
        LOSE, 
        WIN, 
        ENEMYINITIAL,
        PLAYERINITIAL,
        ITEMS
    }

    void Start()
    {
        //sets it to start at the players turn first 
        whosTurn = Turns.PLAYERINITIAL; 
    }

    void Update()
    {
        //switch sets different cases that will be active depending on the whosTurn variable. 
       switch(whosTurn)
        {
            //PLAYERINITIAL starts before anything else and makes sure the item menu is not on during the players turn by shuting it off before starting PLAYERTURN. 
            case (Turns.PLAYERINITIAL):
                itemMenu.SetActive(false);
                whosTurn = Turns.PLAYERTURN; 
                break; 
            case (Turns.PLAYERTURN):
                //UIBattleMenu is SetActive so that the player can click the on screen buttons to use Items, Attack and pass their turn.  
                //timescale is set to zero so that the enemy can't attack the player during the players turn. 
                UIBattleMenu.SetActive(true); 
                //freezes time while player picks options from the battle menu. 
                Time.timeScale = 0.0f;
             
                break;
                // at the begging of the enemys turn the game makes sure itemMenu if off, resets the positions of the enemy attacks and the player and randomly desiding which Attck position set will spawn. 
            case (Turns.ENEMYINITIAL):
                itemMenu.SetActive(false);
                ResetAttack(); 
                ChangeAttackPositions();
                whosTurn = Turns.ENEMYTURN;
                break; 
            case (Turns.ENEMYTURN):
                //ResetAttackPositions(); 
                //calls the UpdateEnemyTurnTimer method that I created below. 
                UpdateEnemyTurnTimer();
                
                //sets the menu so that it is not active and will not be on screen during the enemys turn. 
                UIBattleMenu.SetActive(false);
                //sets timescale back to normal so that the enemy can attack again. 
                Time.timeScale = 1.0f;
                break;
                //activates the Item Menu so the player can use an item during their turn. 
            case (Turns.ITEMS):
                UIBattleMenu.SetActive(false); 
                itemMenu.SetActive(true);
                break; 
            case (Turns.LOSE):
                break;
            case (Turns.WIN):
                break;
        }
        //displayes the win screen scene if enemy is killed. 
        if (EnemyHealth <= 0)
        {
            SceneManager.LoadScene("Win");
           
        }
    }
    //creates turntimer method. 
    void UpdateEnemyTurnTimer()
    {
        //starts ticking the timer to move up by one per second. 
        EnemyTurnTimer += Time.deltaTime;
        //if the enemy timer is greater than there turn is supposed to be reset the timer and go to the players turn. 
        if (EnemyTurnTimer >= EnemyTurnDuration)
        {
           
            EnemyTurnTimer = 0;
            whosTurn = Turns.PLAYERINITIAL;
            //Debug.Log("PlayerTurn!!!!"); 
        }
        
    }
    //creates method to set the ItemMenu on while makeing sure attack mode is disabled if the player uses an item for their next turn. 
    public void itemMenuStart()
    {
        AttackMode = false;
        whosTurn = Turns.ITEMS; 
    }
    //creates method so that when that player uses the Cake Item in inventory there health is raised and the enemy's turn starts. 
    public void HealthIteam()
    {
        Health.life++;
        whosTurn = Turns.ENEMYINITIAL; 
    }
    //creates method allowing player to back out of the Item Menu with the back button. 
    public void Back()
    {
        whosTurn = Turns.PLAYERINITIAL; 
    }
    //creates player attack method. 
    public void PlayerAttack()
    {
        Debug.Log("ATTACK!!!"); 

        if (whosTurn == Turns.PLAYERTURN)
        {
            //if player attacks during their turn enemy health is taken down by one. 
            EnemyHealth -= 1;
            AttackMode = true; 
          //  Debug.Log("EnemyTurn!!!");
            //sets it back to enemys turn after player attacks. 
            whosTurn = Turns.ENEMYINITIAL;
        }
    }
    //creates playerpass method. 
    public void PlayerPass()
    {
        //if player passes their turn it simply goes to the enemys turn. 
        AttackMode = false; 
        whosTurn = Turns.ENEMYINITIAL; 
    }
    
   // This method is use to randomize the attacks  so they do not spawn in the same area every time by seting the objects that atack positions are saved in to true or false depending on the number 
    public void ChangeAttackPositions()
    {
        randomNum = Random.Range(1, 3); 
        if (randomNum == 1)
        {
            AttackBulletsOne.SetActive(true);
            AttackBulletsTwo.SetActive(false);
            AttackBulletsThree.SetActive(false); 
        }
        else if (randomNum == 2)
        {
            AttackBulletsOne.SetActive(false);
            AttackBulletsTwo.SetActive(true);
            AttackBulletsThree.SetActive(false); 
        }
        else
        {
            AttackBulletsOne.SetActive(false);
            AttackBulletsTwo.SetActive(false);
            AttackBulletsThree.SetActive(true); 
        }

    }
    //method that resets the players heart position then uses a for loop to reset the positions of all the attacks. 
    public void ResetAttack()
    {
        mySoul.ResetSoul();
        for (int i = 0; i < AttackOne.Length; i++)
        {
            
            AttackOne[i].ResetItem(); 
        }

        for (int i = 0; i < AttackTwo.Length; i++)
        {
            AttackTwo[i].ResetItem();
        }

        for (int i = 0; i < AttackThree.Length; i++)
        {
            AttackThree[i].ResetItem();
        }
    }
}