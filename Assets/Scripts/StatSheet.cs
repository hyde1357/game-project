using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSheet : MonoBehaviour
{
    public float STR; // 0, Strength
    public float STRMod;
    public float DEX; // 1, Dexterity
    public float DEXMod;
    public float CON; // 2, Constitution
    public float CONMod;
    public float GS1; // 3, Generic skill for testing skill checks
    public float GS1Mod;
    public float XP;
    public float HP;
    public float DEF;
    private readonly List<StatBase> CharacterStats = new List<StatBase>();
    Random dice = new Random(); // Random number generator

    public void Start()
    {
        calculateStats();
    }

    public void calculateStats()
    {
        // Strength
        StatBase str = new StatBase(STR);
        str.AddModifier(new StatModifier(STRMod));
        CharacterStats.Add(str);
        Debug.Log("Strength: " + CharacterStats[0].Value.ToString());
        
        // Dexterity
        StatBase dex = new StatBase(DEX);
        dex.AddModifier(new StatModifier(DEXMod));
        CharacterStats.Add(dex);
        Debug.Log("Dexterity: " + CharacterStats[1].Value.ToString());
        
        // Constitution
        StatBase con = new StatBase(CON);
        con.AddModifier(new StatModifier(CONMod));
        CharacterStats.Add(con);
        Debug.Log("Constitution: " + CharacterStats[2].Value.ToString());

        // Generic Skill 1
        StatBase gs1 = new StatBase(GS1);
        gs1.AddModifier(new StatModifier(GS1Mod));
        CharacterStats.Add(gs1);
        Debug.Log("Generic skill 1: " + CharacterStats[3].Value.ToString());

        // Initialize hit points, defense & XP
        HP = 10 + CONMod;
        DEF = 10 + DEXMod;
        XP = 0;
        Debug.Log("HP: " + HP.ToString() + ", Defense: " + DEF.ToString() + ", XP: " + XP.ToString());
    }
}
