using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> allItems;

    public Item GetItemById(string id)
    {
        if (string.IsNullOrEmpty(id)) return null;
        return allItems.Find(x => x.id == id);
    }
}