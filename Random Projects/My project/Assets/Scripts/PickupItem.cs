using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public ItemSO item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if (item == null)
        {
            Debug.LogError("PickupItem has no ItemSO assigned!", gameObject);
            return;
        }

        Inventory inv = collision.GetComponent<Inventory>();
        if (inv == null)
        {
            Debug.LogError("Player has no Inventory component!");
            return;
        }

        inv.AddItem(item);

        Destroy(gameObject);
    }
}