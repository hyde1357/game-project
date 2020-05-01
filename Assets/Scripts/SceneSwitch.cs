using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    GameObject player;
    GameObject enemy;
    BattleScene battleScene;

    // Get index of scene
    int sceneIndex;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        //Debug.Log("---------START-------------" + sceneIndex);
    }
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(1);
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        //Debug.Log("---------TRIGG---------------" + sceneIndex);
    }

    public void PostBattle(int index)
    {
        //if (battleScene.CheckPlayerCON())
        
        SceneManager.LoadScene(index);
        Debug.Log("pressed RUN");
        //Debug.Log("----------------------------" + sceneIndex);
        //sceneIndex = SceneManager.GetActiveScene().buildIndex;


    }
}
