using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    void Start()
    {
        //Debug.Log("---------START-------------" + sceneIndex);
    }
    void OnTriggerEnter(Collider other)
    {
        //player.GetComponent<AudioSource>().Stop();
        //DontDestroyOnLoad(player);
        DontDestroyOnLoad(enemy);
        SceneManager.LoadScene(1);
    }

    public void Run()
    {
        SceneManager.LoadScene(0);
        Debug.Log("pressed RUN");
        Destroy(enemy);
    }
}
