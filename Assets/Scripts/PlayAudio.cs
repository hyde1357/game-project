using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public void Step()
    {
        AudioSource sound = gameObject.GetComponent<AudioSource>();
        sound.Play();
    }
}
