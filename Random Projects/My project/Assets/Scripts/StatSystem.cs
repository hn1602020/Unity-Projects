using System;
using UnityEngine;

[Serializable]
public class Stats
{
    public int level = 1;
    public int currentXP = 0;
    public int xpToNextLevel = 100;
    public int baseHP = 100;
    public int currentHP = 100;
    public int attack = 10;
    public int defense = 5;

    public void GainXP(int amount)
    {
        currentXP += amount;
        while (currentXP >= xpToNextLevel)
        {
            currentXP -= xpToNextLevel;
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        baseHP += 10;
        attack += 3;
        defense += 2;
        currentHP = baseHP; // heal on level
        xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * 1.25f);
        Debug.Log("Level Up! Now level " + level);
    }
}
