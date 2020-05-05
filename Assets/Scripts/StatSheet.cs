using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSheet : MonoBehaviour
{
    public float STR; // 0, Strength
    private float STRMod;
    public float DEX; // 1, Dexterity
    private float DEXMod;
    public float CON; // 2, Constitution
    private float CONMod;
    public float XP;
    public float HP;
    public float DEF;
    public int level;
    public List<StatBase> CharacterStats = new List<StatBase>();
    public List<float> StatModifiers = new List<float>();
    Random dice = new Random(); // Random number generator

    public void Start()
    {
        calculateStats();
    }

    public void calculateStats()
    {
        // Strength
        STRMod = calculateMod(STR);
        CharacterStats.Add(new StatBase(STR));
        StatModifiers.Add(STRMod);
        //Debug.Log("Strength: " + CharacterStats[0].Value.ToString() + ", mod " + StatModifiers[0].ToString());

        // Dexterity
        DEXMod = calculateMod(DEX);
        CharacterStats.Add(new StatBase(DEX));
        StatModifiers.Add(DEXMod);
        //Debug.Log("Dexterity: " + CharacterStats[1].Value.ToString() + ", mod " + StatModifiers[1].ToString());

        // Constitution
        CONMod = calculateMod(CON);
        CharacterStats.Add(new StatBase(CON));
        StatModifiers.Add(CONMod);
        //Debug.Log("Constitution: " + CharacterStats[2].Value.ToString() + ", mod " + StatModifiers[2].ToString());

        // Initialize hit points, defense, level & XP
        HP = 10 + CONMod;
        DEF = 10 + DEXMod;
        level = 1;
        XP = 0;
        //Debug.Log("HP: " + HP.ToString() + ", Defense: " + DEF.ToString() + ", XP: " + XP.ToString() + ", level: " + level.ToString());
    }

    private float calculateMod(float stat)
    {
        float mod;
        if (stat <= 5) { mod = -3; }
        else if (stat == 6 || stat == 7) { mod = -2; }
        else if (stat == 8 || stat == 9) { mod = -1; }
        else if (stat == 10 || stat == 11) { mod = 0; }
        else if (stat == 12 || stat == 13) { mod = 1; }
        else if (stat == 14 || stat == 15) { mod = 2; }
        else if (stat == 16 || stat == 17) { mod = 3; }
        else if (stat == 18 || stat == 19) { mod = 4; }
        else { mod = 5; }
        return mod;
    }
}
