using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public PlayerStatsMono player;

    public void Save()
    {
        PlayerPrefs.SetInt("level", player.stats.level);
        PlayerPrefs.SetInt("xp", player.stats.currentXP);
        PlayerPrefs.SetInt("hp", player.stats.currentHP);
        // Save equipment as ids (strings)
        PlayerPrefs.SetString("weapon", EquipmentManager.Instance.weapon != null ? EquipmentManager.Instance.weapon.id : "");
        PlayerPrefs.SetString("armor", EquipmentManager.Instance.armor != null ? EquipmentManager.Instance.armor.id : "");
        PlayerPrefs.Save();
    }

    public void Load()
    {
        if (!PlayerPrefs.HasKey("level")) return;
        player.stats.level = PlayerPrefs.GetInt("level");
        player.stats.currentXP = PlayerPrefs.GetInt("xp");
        player.stats.currentHP = PlayerPrefs.GetInt("hp");
        string wid = PlayerPrefs.GetString("weapon");
        string aid = PlayerPrefs.GetString("armor");

        // For demo: you need a lookup to convert id -> Item. Implement a small ItemDatabase.
        var db = FindObjectOfType<ItemDatabase>();
        if (db)
        {
            //EquipmentManager.Instance.weapon = db.GetItemById(wid);
            //EquipmentManager.Instance.armor = db.GetItemById(aid);
        }
    }
}