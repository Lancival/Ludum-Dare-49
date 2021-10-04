using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

// Add this to the player
public class Inventory
{
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;

    public Inventory() {
        itemList = new List<Item>();

        /* Test adding items */
        // REMOVE IN FINAL VERSION
        // AddItem(new Item {itemType = Item.ItemType.Item1, amount=1});
        // AddItem(new Item {itemType = Item.ItemType.Item2, amount=1});
        // AddItem(new Item {itemType = Item.ItemType.Item3, amount=1});
        // AddItem(new Item {itemType = Item.ItemType.Item3, amount=1});
        // AddItem(new Item {itemType = Item.ItemType.Item3, amount=1});
        // AddItem(new Item {itemType = Item.ItemType.Item3, amount=1});

        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item) {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item) {
        itemList.Remove(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public List<Item> GetItemList()
    {
        return itemList;
    }

    public int GetItemListCount()
    {
        return itemList.Count;
    }
}
