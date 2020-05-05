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
        RAN
    }
    public MapStates currentState;

    void Start()
    {
        sceneTransitions = 0;
        currentState = MapStates.NORMAL;
    }
}
