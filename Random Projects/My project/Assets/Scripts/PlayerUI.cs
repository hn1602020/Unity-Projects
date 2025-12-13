using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public EquipmentManager equipment;

    public Image weaponIcon;
    public Image armorIcon;

    void Update()
    {
        // Weapon Icon
        if (equipment.weapon != null)
        {
            weaponIcon.sprite = equipment.weapon.icon;
            weaponIcon.enabled = true;
        }
        else
        {
            weaponIcon.enabled = false;
        }

        // Armor Icon
        if (equipment.armor != null)
        {
            armorIcon.sprite = equipment.armor.icon;
            armorIcon.enabled = true;
        }
        else
        {
            armorIcon.enabled = false;
        }
    }
}