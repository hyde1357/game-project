using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : MonoBehaviour
{
    public GameObject playerCube;
    public GameObject otherCube;
    private GameObject[] enemies;

    public FightMenu battleUI;

    public enum BattleStates {
        NONE,
        BEGIN,
        PLAYERTURN,
        ENEMYTURN,
        WIN,
        LOSE
    }


    //create BattleStates variable to control the state of battle
    public BattleStates currentState;
    public Distance d;
    SkillCheck enemyInteractVals;

    void Start()
    {

        // Fills array with gameobjects tagged as "enemy"
        enemies = GameObject.FindGameObjectsWithTag("enemy");

        otherCube = null;

        // Set currentState to NONE
        currentState = BattleStates.NONE;
    }

    void Update()
    {
        // Changes currentState if CheckDistance from Distance class returns true
        changeStateFromDistance();

        // Checks to see what the currentState is, sends message to console.

        checkStates();

        //Looking for an enemy that's close by
        otherCube = FindClosestEnemy();
        enemyInteractValsSetup();
    }

    private void enemyInteractValsSetup()
    {
        if (otherCube != null)
        {
            // create a skillchecker object using the interact values assigned
            // to the enemy in unity's inspector
            enemyInteractVals = new SkillCheck(otherCube.GetComponent<Interact>().d, otherCube.GetComponent<Interact>().dCount, otherCube.GetComponent<Interact>().mod);
        }
    }

    private void changeStateFromDistance()
    {
        // changes the BattleState to BEGIN to initiate the fight
        // if the distance between two items is less than 3
        if (otherCube!= null)
        {
            currentState = BattleStates.BEGIN;
        }
        else
            currentState = BattleStates.NONE;
    }

    //Used to check the currentState . use as debugger to see if the state
    // is displaying correctly.
    void checkStates()
    {
        if (currentState == BattleStates.BEGIN)
        {
            //battleUI.FightEnsued = true;
            Debug.Log("CURRENTSTATE IS BEGIN");
        }
    }

    // Set up button "FIGHT" to attack the enemy
    // Temporary solution as we get the UI set up
    void OnGUI()
    {
        // If the "Fight" button on gui is pressed
        if (GUILayout.Button("Fight"))
        {
            if (currentState == BattleStates.BEGIN)
            {
                currentState = BattleStates.PLAYERTURN;

                if (currentState == BattleStates.PLAYERTURN)
                {
                    PlayerTurn();
                    currentState = BattleStates.ENEMYTURN;
                }

                if (currentState == BattleStates.ENEMYTURN)
                {
                    EnemyTurn();
                    currentState = BattleStates.PLAYERTURN;
                }
            }

//TODO fix mechanic so battlestate doesn't always
// go back to "BEGIN" after player wins or loses
// look @ the distance function changeStateFromDistance()
            if (currentState == BattleStates.LOSE || currentState == BattleStates.WIN)
            {
                currentState = BattleStates.NONE;
            }
        }
    }

    private void EnemyTurn()
    {
        // Check to see if roll against enemy is success
        // by using enemy's Interact script
        if (enemyInteractVals.CheckSuccess(0, 0) == true)
        {
            // Deal damage to playerCube by getting CON 
            // and subtracting it by the Roll() value
            playerCube.GetComponent<StatSheet>().CON -= enemyInteractVals.Roll();
            Debug.Log("ENEMY hit PLAYER.");
        } else Debug.Log("PLAYER dodged!");

        if (playerCube.GetComponent<StatSheet>().CON <= 0)
        {
            currentState = BattleStates.LOSE;
            Debug.Log("PLAYER has LOST the battle.");
        }
    }

    private void PlayerTurn()
    {
        // Check to see if roll against player is success
        // by using enemy's Interact script
        if (enemyInteractVals.CheckSuccess(0, 0) == true)
        {
            // Deal damage to otherCube by getting CON 
            // and subtracting it by the Roll() value
            otherCube.GetComponent<StatSheet>().CON -= enemyInteractVals.Roll();
            Debug.Log("PLAYER hit ENEMY.");
        } else Debug.Log("ENEMY dodged!");

        if (otherCube.GetComponent<StatSheet>().CON <= 0)
        {
            currentState = BattleStates.WIN;
            Debug.Log("PLAYER has WON the battle.");
        }
    }

    // Finds the closest enemy
    // Not yet optimized to handle multiple enemies within the same radius
    public GameObject FindClosestEnemy()
    {
        GameObject closest = null;
        foreach (GameObject GO in enemies)
        {
            d = new Distance(playerCube, GO);
            if (d.CheckDistance())
            {
                closest = GO;
            }
        }
        return closest;
    }
}
