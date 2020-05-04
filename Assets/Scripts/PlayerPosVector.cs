using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerPosVector : ScriptableObject
{
    public Vector3 initialValue;
    public int sceneTransitions;

    void Start()
    {
        sceneTransitions = 0;
    }
}
