﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float xpGain; // Awarded xp for success
    public int difficulty; // Required total for success
    public int d; //d4, d6, d8, d10, d20 etc.
    public int dCount; // How many dice are used?
    public int mod; // Relevant skill modifier
    private SkillCheck roll;

    // Roll for attack
    public int AttackRoll()
    {
        difficulty = gameObject.GetComponent<StatSheet>().DEF;
        roll = new SkillCheck(d, dCount, mod);
        return roll.Roll();
    }

    // Roll for damage


    // Test stuff, disabled
    /*private void OnTriggerEnter(Collider other)
    {
        SkillCheck roll = new SkillCheck(d, dCount, mod);
        bool success = roll.CheckSuccess(difficulty, roll.Roll());
        if(success == true)
        {
            roll.AwardXP(xpGain);
        }
    }*/
}
