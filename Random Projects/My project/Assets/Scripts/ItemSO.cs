using UnityEngine;

public enum ItemType { Consumable, Equipment }
public enum EquipSlot { None, Weapon, Armor }

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/Item")]
public class ItemSO : ScriptableObject
{
    public string id;
    public string displayName;
    public ItemType itemType;
    public EquipSlot equipSlot = EquipSlot.None;
    public int attackBonus;
    public int defenseBonus;
    public int hpBonus;
    public Sprite icon;
    public int xpValue;
}