using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleScene : MonoBehaviour
{
    public GameObject playerCube;

    public GameObject otherCube;
    private GameObject[] enemies;

    public FightMenu battleUI;
    public PlayerPosVector playerPosVector;



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

    void Start()
    {

        // Fills array with gameobjects tagged as "enemy"
        enemies = GameObject.FindGameObjectsWithTag("enemy");

        otherCube = null;

        currentState = BattleStates.BEGIN;
        playerPosVector.currentState = PlayerPosVector.MapStates.NORMAL;
    }

    void Update()
    {
        // Changes currentState if CheckDistance from Distance class returns true
        changeStateFromDistance();

        // Checks to see what the currentState is, sends message to console.

        //checkStates();

        //Looking for an enemy that's close by
        otherCube = FindClosestEnemy();
    }

    public void ChangeBattleState(BattleStates state)
    {
        currentState = state;
    }

    private void changeStateFromDistance()
    {
        // changes the BattleState to BEGIN to initiate the fight
        // if the distance between two items is less than 3
        if (otherCube != null)
        {
            currentState = BattleStates.BEGIN;
            playerPosVector.currentState = PlayerPosVector.MapStates.BATTLE;
        }
        else
        {
            currentState = BattleStates.NONE;
            playerPosVector.currentState = PlayerPosVector.MapStates.NORMAL;
        }
    }

    //Used to check the currentState . use as debugger to see if the state
    // is displaying correctly.
    public BattleStates checkStates()
    {
        //Debug.Log("The current state is : " + currentState);
        return currentState;
    }
    
    // Set up button "FIGHT" to attack the enemy
    // Temporary solution as we get the UI set up
    public void OnGUI()
    {
            if (currentState == BattleStates.BEGIN)
            {
                currentState = BattleStates.PLAYERTURN;

                if (currentState == BattleStates.PLAYERTURN)
                {
                    PlayerTurn();
                    //playerCube.GetComponent<StatSheet>().PrintStats();
                    //otherCube.GetComponent<StatSheet>().PrintStats();
                    currentState = BattleStates.ENEMYTURN;
                }

                if (currentState == BattleStates.ENEMYTURN)
                {
                    EnemyTurn();
                    //playerCube.GetComponent<StatSheet>().PrintStats();
                    //otherCube.GetComponent<StatSheet>().PrintStats();
                    currentState = BattleStates.PLAYERTURN;
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

    public void EnemyTurn()
    {
        // Enemy hit check roll
        SkillCheck enemyHitCheck = new SkillCheck(20, 1, otherCube.GetComponent<StatSheet>().STRMod);
        int roll = enemyHitCheck.Roll();

        // Check if enemy hit player
        if(enemyHitCheck.CheckSuccess(playerCube.GetComponent<StatSheet>().DEF, roll) == true)
        {
            // Damage roll
            SkillCheck damageCheck = new SkillCheck(6, 1, otherCube.GetComponent<StatSheet>().STRMod);
            playerCube.GetComponent<StatSheet>().HP -= damageCheck.Roll();
            Debug.Log("ENEMY hit PLAYER.");
        } else Debug.Log("PLAYER dodged!");

        CheckPlayerHP();
        CheckEnemyHP();
    }

    public void PlayerTurn()
    {
        // Check to see if roll against player is success
        // by using enemy's Interact script
        bool attackRoll = otherCube.GetComponent<Interact>().AttackRoll(playerCube.GetComponent<StatSheet>().STRMod);
        if (attackRoll == true)
        {
            if (currentState == BattleStates.PLAYERTURN)
            {
                // Damage roll
                SkillCheck damageCheck = new SkillCheck(6, 1, otherCube.GetComponent<StatSheet>().STRMod);
                otherCube.GetComponent<StatSheet>().HP -= damageCheck.Roll();
                Debug.Log("FIGHT");

                // TODO this is SUPPOSED to animate an attack
                //playerCube.GetComponentInChildren<MovementControls>().anim.SetInteger("condition", 3);
            }

        } else Debug.Log("ENEMY dodged!");

        CheckPlayerHP();
        CheckEnemyHP();
        EnemyTurn();
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


    public bool CheckPlayerHP()
    {
        // Check if player has hp that is 0
        if (playerCube.GetComponent<StatSheet>().HP <= 0)
        {
            currentState = BattleStates.LOSE;
            Debug.Log("PLAYER has LOST the battle.");
            return true;
        }
        else return false;
    }
    public bool CheckEnemyHP()
    {
        if (otherCube.GetComponent<StatSheet>().HP <= 0)
        {
            currentState = BattleStates.WIN;
            Debug.Log("PLAYER has WON the battle.");
            otherCube.SetActive(false);
            return true;
        }
        else return false;
    }

    public void onRun()
    {
        if (checkStates() == BattleStates.WIN)
        {
            Destroy(otherCube);
        }
    }

    public void Run()
    {
        playerPosVector.currentState = PlayerPosVector.MapStates.RAN;
        Debug.Log("pressed RUN");
        currentState = BattleStates.LOSE;
        otherCube.SetActive(false);
        enemies = GameObject.FindGameObjectsWithTag("enemy");
    }

}
