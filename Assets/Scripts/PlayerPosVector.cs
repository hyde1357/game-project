using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerPosVector : ScriptableObject
{
    public Vector3 initialValue;
    public int sceneTransitions;
    public GameObject enemy;

    public enum MapStates
    {
        NORMAL,
        BATTLE,
        RAN
    }
    public MapStates currentState;

    void Start()
    {
        currentState = MapStates.NORMAL;
    }

    void Awake()
    {
        sceneTransitions = 0;
    }
}
