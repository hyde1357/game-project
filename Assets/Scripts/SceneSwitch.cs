using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    public Vector3 playerPosition;
    public PlayerPosVector playerStorage;
    public BattleScene battleScene;

    float curDist = 2f;

    void Start()
    {
        FindSkeleton();
        //player.GetComponent<AudioSource>().Stop();
        //DontDestroyOnLoad(player);
        //Invoke("DestroyEnemy", 2f);
        //playerStorage.currentState = PlayerPosVector.MapStates.NORMAL;
        //Debug.Log(playerStorage.currentState);
    }
    void OnTriggerEnter(Collider other)
    {
        //FindSkeleton();

        playerStorage.initialValue = playerPosition;
        playerStorage.sceneTransitions++;
        SceneManager.LoadScene(1);
        battleScene.currentState = BattleScene.BattleStates.PLAYERTURN;
        Debug.Log(battleScene.currentState);
    }

    private void FindSkeleton()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        float curDist = 2f;

        foreach (GameObject item in enemies)
        {
            float dist = Vector3.Distance(transform.position, item.transform.position);
            if (dist < curDist)
            {
                curDist = dist;
                playerStorage.enemy = item;
            }
        }
        if(playerStorage.enemy != null && playerStorage.currentState == PlayerPosVector.MapStates.RAN) 
        {
            Invoke("DestroyEnemy", 2f);
        }
        else
        {
            Debug.Log(playerStorage.currentState);
        }
        //Debug.Log("Skeleton found, distance: " + playerStorage.enemy.GetComponent<Transform>.ToString());
    }

    public void Run()
    {
        playerStorage.sceneTransitions++;
        playerStorage.currentState = PlayerPosVector.MapStates.RAN;
        Debug.Log("pressed RUN");
        battleScene.currentState = BattleScene.BattleStates.LOSE;
        Debug.Log("PLAYER CHOICE" + battleScene.currentState);
        SceneManager.LoadScene(0);
        playerStorage.initialValue = playerPosition;
    }

    void DestroyEnemy()
    {

        if (playerStorage.currentState == PlayerPosVector.MapStates.RAN) { 
            RemoveEnemy();
        }
        else
        {
            return;
        }
    }

    private void RemoveEnemy()
    {
        Debug.Log("RemoveEnemy called");
        playerStorage.enemy.SetActive(false);
        playerStorage.currentState = PlayerPosVector.MapStates.NORMAL;
        Debug.Log(playerStorage.currentState);
    }

}