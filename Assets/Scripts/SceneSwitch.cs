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

    void Start()
    {
        //player.GetComponent<AudioSource>().Stop();
        //DontDestroyOnLoad(player);
    }
    void OnTriggerEnter(Collider other)
    {
        playerStorage.initialValue = playerPosition;
        playerStorage.sceneTransitions++;
        SceneManager.LoadScene(1);
        battleScene.currentState = BattleScene.BattleStates.PLAYERTURN;
        Debug.Log(battleScene.currentState);
    }

    public void Run()
    {
        playerStorage.sceneTransitions++;
        Debug.Log("pressed RUN");
        battleScene.currentState = BattleScene.BattleStates.LOSE;
        Debug.Log("PLAYER CHOICE" + battleScene.currentState);
        SceneManager.LoadScene(0);
        playerStorage.initialValue = playerPosition;
    }
}