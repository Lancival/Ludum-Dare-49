using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add this to the player
public class Inventory
{
    private List<Item> itemList;

    public Inventory() {
        itemList = new List<Item>();

        AddItem(new Item {itemType = Item.ItemType.Item1, amount =1});
        AddItem(new Item {itemType = Item.ItemType.Item2, amount=1});
        AddItem(new Item {itemType = Item.ItemType.Item3, amount=1});
        Debug.Log("Inventory");
    }

    public void AddItem(Item item) {
        itemList.Add(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
