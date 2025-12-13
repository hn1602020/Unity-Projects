using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int capacity = 20;
    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (items.Count >= capacity) return false;
        items.Add(item);
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    internal void AddItem(ItemSO item)
    {
        throw new NotImplementedException();
    }

    internal void AddItemm(ItemSO item)
    {
        throw new NotImplementedException();
    }
}

