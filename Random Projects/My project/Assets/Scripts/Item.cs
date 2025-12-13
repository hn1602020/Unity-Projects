using UnityEngine;

[System.Serializable]

public class Item
{
    public string id;
    public string displayName;
    public ItemType itemType;
    public EquipSlot equipSlot;
    public int attackBonus;
    public int defenseBonus;
    public int hpBonus;
    public Sprite icon;
    public int xpValue; // if this item gives XP (like XP orb)
}

