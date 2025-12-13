using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    public ItemSO weapon;
    public ItemSO armor;

    public void Equip(ItemSO item)
    {
        if (item == null) return;

        if (item.equipSlot == EquipSlot.Weapon) weapon = item;
        else if (item.equipSlot == EquipSlot.Armor) armor = item;

        // TODO: update visuals (swap weapon sprite) and UI
    }

    public void Unequip(EquipSlot slot)
    {
        if (slot == EquipSlot.Weapon) weapon = null;
        if (slot == EquipSlot.Armor) armor = null;
    }

    public int GetTotalAttackBonus()
    {
        int v = 0;
        if (weapon != null) v += weapon.attackBonus;
        if (armor != null) v += armor.attackBonus;
        return v;
    }

    public int GetTotalDefenseBonus()
    {
        int v = 0;
        if (weapon != null) v += weapon.defenseBonus;
        if (armor != null) v += armor.defenseBonus;
        return v;
    }
}

