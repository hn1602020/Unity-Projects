using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject pickupPrefab; // your Pickup prefab

    void Start()
    {
        // Create a test sword item
        ItemSO sword = ScriptableObject.CreateInstance<ItemSO>();
        sword.displayName = "Test Sword";
        sword.attackBonus = 5;
        sword.equipSlot = EquipSlot.Weapon;
        sword.itemType = ItemType.Equipment;

        // Spawn pickup in the scene
        GameObject pickup = Instantiate(pickupPrefab, transform.position, Quaternion.identity);
        pickup.GetComponent<PickupItem>().item = sword;
    }
}
