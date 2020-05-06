using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMenu : MonoBehaviour
{
    public static bool FightEnsued = false;

    public GameObject pauseMenuUI;
    public BattleScene battleSceneRef;

    public PlayerPosVector playerPosVector;

    void Update()
    {
        CheckPlayerPosVectorState();
        if (FightEnsued)
        {
            Pause();
            print("Fight pause");

        }
        else
        {
            Resume();
        } 
    }

    private void CheckPlayerPosVectorState()
    {
        if (playerPosVector.currentState == PlayerPosVector.MapStates.BATTLE)
        {
            FightEnsued = true;
            //print(FightEnsued);
        }
        else
        {
            FightEnsued = false;
            //print(FightEnsued);
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void Pause()
    {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
    }
}
