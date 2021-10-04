using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : Interactable
{
    // String will determine what item to add to inventory
    [SerializeField]
    private string ItemType;

    void Start()
    {
        string formattedItemType = "$" + char.ToUpper(ItemType[0]) + ItemType.Substring(1);
        Inventory inventory = GameObject.Find("Player").GetComponent<Player>().GetInventory();
        if (inventory.GetItemsPickedUp().Contains(formattedItemType))
        {
            this.gameObject.SetActive(false);
        }
    }

    public override void interact()
    {
        Inventory inventory = GameObject.Find("Player").GetComponent<Player>().GetInventory();
        if (inventory == null)
        {
           Debug.LogError("Couldn't find the player inventory");
           return;
        }
        // Use case statements to remove outline and add to inventory
        if (ItemType == "cables")
        {
            inventory.AddItem(new Item {itemType = Item.ItemType.Item3, amount=1});
            inventory.setItem(ItemType);
            this.gameObject.SetActive(false);
        }
        else if (ItemType == "paints")
        {
            inventory.AddItem(new Item {itemType = Item.ItemType.Item6, amount=1});
            inventory.setItem(ItemType);
            this.gameObject.SetActive(false);
        }
        else if ( ItemType == "poems")
        {
            inventory.AddItem(new Item {itemType = Item.ItemType.Item1, amount=1});
            inventory.setItem(ItemType);
            this.gameObject.SetActive(false);
        }
        else if ( ItemType == "sketchbook")
        {
             inventory.AddItem(new Item {itemType = Item.ItemType.Item8, amount=1});
             inventory.setItem(ItemType);
            this.gameObject.SetActive(false);
        }
        else if ( ItemType == "suitcase")
        {
            inventory.AddItem(new Item {itemType = Item.ItemType.Item10, amount=1});
            inventory.setItem(ItemType);
            this.gameObject.SetActive(false);
        }
        else if ( ItemType == "travelbook")
        {
            inventory.AddItem(new Item {itemType = Item.ItemType.Item11, amount=1});
            inventory.setItem(ItemType);
            this.gameObject.SetActive(false);
        }
        else if ( ItemType == "business")
        {
            inventory.AddItem(new Item{itemType = Item.ItemType.Item2, amount=1});
            inventory.setItem(ItemType);
            this.gameObject.SetActive(false);
        }
        else if ( ItemType == "ladder")
        {
            inventory.AddItem(new Item{itemType = Item.ItemType.Item5, amount=1});
            inventory.setItem(ItemType);
            this.gameObject.SetActive(false);
        }
        else if ( ItemType == "steering_wheel")
        {
            // TODO: Should check if the ladder has been placed
            inventory.AddItem(new Item{itemType = Item.ItemType.Item9, amount=1});
            inventory.setItem(ItemType);
            this.gameObject.SetActive(false);
        }
        else if ( ItemType == "rotary")
        {
            inventory.AddItem(new Item{itemType = Item.ItemType.Item7, amount=1});
            inventory.setItem(ItemType);
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Invalid ItemType specified for interactable");
        }

    }

}
