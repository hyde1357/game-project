﻿using UnityEngine;

public class SkillCheck
{
    public int d; //d4, d6, d8, d10, d20 etc.
    public int dCount; // How many dice are used?
    public int mod; // Relevant skill modifier
    
    // Constructor
    public SkillCheck(int D, int DCount, int Mod)
    {
        d = D;
        dCount = DCount;
        mod = Mod;
    }

    // Roll
    // Commented out Debug.Log for less clutter.
    public int Roll()
    {
        int total = 0;
        System.Random dice = new System.Random();
        for (int i = 1; i <= dCount; i++)
        {
            int roll = dice.Next(1, d);
            total += roll;
            Debug.Log("d " + i.ToString() + " value: " + roll.ToString());
        }
        total += Mathf.RoundToInt(mod);
        //Debug.Log("Roll " + dCount.ToString() + "d" + d.ToString() + " + " + mod.ToString() + ". Result: " + total.ToString());
        return total;
    }

    // Commented out Debug.Log for less clutter.
    public bool CheckSuccess(int difficulty, int total)
    {
        bool success = false;
        if(total >= difficulty)
        {
            success = true;
            //Debug.Log("Success!");
        }
        else
        {
            success = false;
            //Debug.Log("Fail!");
        }
        return success;
    }

    // Commented out Debug.Log for less clutter.
    public void AwardXP(int xpGain)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<StatSheet>().XP += xpGain;
        Debug.Log("Rewarded with " + xpGain.ToString() + " xp. Current xp: " + GameObject.FindGameObjectWithTag("Player").GetComponent<StatSheet>().XP);
    }
}
