using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float xpGain; // Awarded xp for success
    public int difficulty; // Required total for success
    public int d; //d4, d6, d8, d10, d20 etc.
    public int dCount; // How many dice are used?
    public float mod; // Relevant skill modifier
    private readonly SkillCheck roll;

    private void OnTriggerEnter(Collider other)
    {
        SkillCheck roll = new SkillCheck(difficulty, d, dCount, mod, xpGain);
        roll.CheckSuccess();
    }
}
