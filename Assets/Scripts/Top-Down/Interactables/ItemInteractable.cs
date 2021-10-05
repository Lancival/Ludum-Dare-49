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
        string formattedItemType = "$" + "has" + ItemType.Substring(0);
        Inventory inventory = GameObject.Find("Player").GetComponent<Player>().GetInventory();
        if (inventory != null && inventory.GetItemsPickedUp().Contains(formattedItemType))
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
        if (ItemType == "Cables")
        {
            inventory.AddItem(new Item {itemType = Item.ItemType.Item3, amount=1});
            inventory.setItem("$hasCables");
            this.gameObject.SetActive(false);
        }
        else if (ItemType == "Paints")
        {
            inventory.AddItem(new Item {itemType = Item.ItemType.Item6, amount=1});
            inventory.setItem("$hasPaints");
            this.gameObject.SetActive(false);
        }
        else if ( ItemType == "Poem")
        {
            inventory.AddItem(new Item {itemType = Item.ItemType.Item1, amount=1});
            inventory.setItem("$hasPoem");
            this.gameObject.SetActive(false);
        }
        else if ( ItemType == "Sketchbook")
        {
             inventory.AddItem(new Item {itemType = Item.ItemType.Item8, amount=1});
             inventory.setItem("$hasSketchbook");
            this.gameObject.SetActive(false);
        }
        else if ( ItemType == "Suitcase")
        {
            inventory.AddItem(new Item {itemType = Item.ItemType.Item10, amount=1});
            inventory.setItem("$hasSuitcase");
            this.gameObject.SetActive(false);
        }
        else if ( ItemType == "TravelBook")
        {
            inventory.AddItem(new Item {itemType = Item.ItemType.Item11, amount=1});
            inventory.setItem("$hasTravelBook");
            this.gameObject.SetActive(false);
        }
        else if ( ItemType == "BusinessCard")
        {
            inventory.AddItem(new Item{itemType = Item.ItemType.Item2, amount=1});
            inventory.setItem("$hasBusinessCard");
            this.gameObject.SetActive(false);
        }
        else if ( ItemType == "Ladder")
        {
            inventory.AddItem(new Item{itemType = Item.ItemType.Item5, amount=1});
            inventory.setItem("$hasLadder");
            this.gameObject.SetActive(false);
        }
        else if ( ItemType == "SteeringWheel")
        {
            // TODO: Should check if the ladder has been placed
            inventory.AddItem(new Item{itemType = Item.ItemType.Item9, amount=1});
            inventory.setItem("$hasSteeringWheel");
            this.gameObject.SetActive(false);
        }
        else if ( ItemType == "RotaryHelm")
        {
            inventory.AddItem(new Item{itemType = Item.ItemType.Item7, amount=1});
            inventory.setItem("$hasRotaryHelm");
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Invalid ItemType specified for interactable");
        }

    }

}
