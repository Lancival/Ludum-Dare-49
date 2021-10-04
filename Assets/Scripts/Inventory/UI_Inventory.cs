using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
   private Inventory inventory;
   // Contains all the item slots
   private Transform itemSlotContainer;

   // References the specific slots
   private Transform[] itemSlots;

   private int numDisplayedItems = 5;

   // Which page of the inventory are we currently on?
   int currentPage;

   private void Awake() {
       currentPage = 0;
       itemSlotContainer = transform.Find("itemSlotContainer");
       itemSlots[0] = transform.Find("slot1");
       itemSlots[1] = transform.Find("slot2");
       itemSlots[2] = transform.Find("slot3");
       itemSlots[3] = transform.Find("slot4");
       itemSlots[4] = transform.Find("slot5");
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
           for (int i = startIndex; i < startIndex + numDisplayedItems-1; i++)
           {
               
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
    
       /*foreach (Transform child in itemSlotContainer) {
           if (child == itemSlotTemplate) continue;
           Destroy(child.gameObject);
       }
       int x = 0;
       int y = 0;
       float itemSlotCellSize = 30f;
       foreach (Item item in inventory.GetItemList()) {
           RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
           itemSlotRectTransform.gameObject.SetActive(true);
           itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
           Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
           image.sprite = item.GetSprite();
           x++;
           if (x>4) {
               x = 0;
               y++;
           }
       }*/
   }
}
