using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMenu : MonoBehaviour
{
    public static bool FightEnsued = false;

    public GameObject pauseMenuUI;
    public BattleScene battleSceneRef;

    void Update()
    {
 /*       //CheckState();
        if (FightEnsued)
        {
            Resume();

        }
        else
        {
            Pause();
        } */
    }

    private void CheckState()
    {
        if (battleSceneRef.checkStates() == BattleScene.BattleStates.BEGIN)
        {
            FightEnsued = true;
        }
        else
        {
            FightEnsued = false;
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
}
