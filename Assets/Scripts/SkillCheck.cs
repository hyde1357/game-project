using UnityEngine;

public class SkillCheck
{
    public float xpGain; // Awarded xp for success
    public int difficulty; // Required total for success
    public int d; //d4, d6, d8, d10, d20 etc.
    public int dCount; // How many dice are used?
    public float mod; // Relevant skill modifier
    public bool success = false; // Result
    System.Random dice = new System.Random(); 
    
    public SkillCheck(int Diff, int D, int DCount, float Mod, float XPGain)
    {
        xpGain = XPGain;
        difficulty = Diff;
        d = D;
        dCount = DCount;
        mod = Mod;
    }

    public bool CheckSuccess()
    {
        int total = 0;
        for(int i = 1; i <= dCount; i++)
        {
            int roll = dice.Next(1, d);
            total += roll;
        }
        Debug.Log("Roll " + dCount.ToString() + "d" + d.ToString() + " + " + mod.ToString() + ". Result: " + total.ToString());
        if((total + Mathf.RoundToInt(mod)) >= difficulty)
        {
            success = true;
            Debug.Log("Success! Rewarded with " + xpGain.ToString() + " xp.");
            AwardXP();
        }
        else
        {
            success = false;
            Debug.Log("Fail!");
        }
        return success;
    }

    private void AwardXP()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<StatSheet>().XP += xpGain;
        Debug.Log("Current xp: " + GameObject.FindGameObjectWithTag("Player").GetComponent<StatSheet>().XP);
    }
}
