using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public ItemSO item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Add item to player's inventory
            Inventory inv = collision.GetComponent<Inventory>();
            inv.AddItem(item);

            // Remove pickup object
            Destroy(gameObject);
        }
    }
}