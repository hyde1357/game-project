using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMenu : MonoBehaviour
{
    public bool FightEnsued = false;

    public GameObject pauseMenuUI;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (FightEnsued == true)
            {
                Pause();
                //Debug.Log("Is true!");
            }

            else
            {
                Resume();
            }
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        FightEnsued = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        FightEnsued = true;
    }
  /*      if (Input.GetKeyDown(KeyCode.Escape))
        {
            FightEnsued = false;
        }
    } */
}
