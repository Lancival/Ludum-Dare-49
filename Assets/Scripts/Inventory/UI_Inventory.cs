using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class UI_Inventory : MonoBehaviour
{
   private Inventory inventory;
   // Contains all the item slots
   private Transform itemSlotContainer;

   // References the specific slots
   private Transform[] itemSlots = null;

   private int numDisplayedItems = 5;

   // Which page of the inventory are we currently on?
   int currentPage;

   private void Awake() {
       currentPage = 0;
       itemSlotContainer = transform.Find("itemSlotContainer");
       itemSlots = new Transform[5];
       itemSlots[0] = itemSlotContainer.Find("slot1");
       itemSlots[1] = itemSlotContainer.Find("slot2");
       itemSlots[2] = itemSlotContainer.Find("slot3");
       itemSlots[3] = itemSlotContainer.Find("slot4");
       itemSlots[4] = itemSlotContainer.Find("slot5");
       
       // Check if slots are not null
       Assert.IsNotNull(itemSlots[0]);
       Assert.IsNotNull(itemSlots[1]);
       Assert.IsNotNull(itemSlots[2]);
       Assert.IsNotNull(itemSlots[3]);
       Assert.IsNotNull(itemSlots[4]); 
   }

   public void SetInventory(Inventory inventory)
   {
       this.inventory = inventory;

       inventory.OnItemListChanged += Inventory_OnItemListChanged;
       RefreshInventoryItems();
   }

   private void Inventory_OnItemListChanged(object sender, System.EventArgs e) {
       RefreshInventoryItems();
   }

   public void RefreshInventoryItems() {
       if (itemSlots == null) return;
       //if (inventory == null) return;

       // Should only display visible items
       int startIndex = currentPage * 5;

       // Check if the arrow should be displayed?
       // I'm assuming that only 7 items can be carried at once
       if ( currentPage == 0)
       {
           if (inventory.GetItemListCount() > 5)
           {
               // Display the forward arrow
           }
       }
       else if (currentPage == 1)
       {
           // Display the backwards arrow
       }
       else
       {
           Debug.LogError("Unexpected item count in inventory\n");
       }
        int slotCounter = 0; // Always start from the leftmost slot 
        for (int i = startIndex; i < numDisplayedItems; i++)
        {
            if (i < startIndex + inventory.GetItemListCount())
            {
                // Display appropriate item image in the correct slot
                // get (slot[number] -> image)
                itemSlots[slotCounter].GetChild(0).gameObject.SetActive(true);
                Image image = itemSlots[slotCounter].GetChild(0).gameObject.GetComponent<Image>();
                image.sprite = inventory.GetItemList()[i].GetSprite();
            }
            else
            {   
                // Deactivate image slots with no items in them
                itemSlots[slotCounter].GetChild(0).gameObject.SetActive(false);
            }
            slotCounter++;
        }
    }
}
