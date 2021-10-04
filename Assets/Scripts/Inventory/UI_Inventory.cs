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

   private Animator m_Animator;

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

       m_Animator = GetComponent<Animator>();
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

   // should be called by SendMessage() from the buttons
   public void ClickInventoryPageRight()
   {
       // Change this if the page isn't correct
       currentPage = 1;
       RefreshInventoryItems();
   }

   public void ClickInventoryPageLeft()
   {
       // Change this if the page isn't correct
       currentPage = 0;
       RefreshInventoryItems();
   }

   // Ewww repeated code yikes :/ 
   public void DisableButtons()
   {
       // Disable right/left buttons first...
       Transform buttonRight = transform.Find("inventoryPageRight");
       if (buttonRight != null)
       {
           Debug.Log("Disabling right button");
           buttonRight.gameObject.SetActive(false);
       }
       Transform buttonLeft = transform.Find("inventoryPageLeft");
       if (buttonLeft != null)
       {
           Debug.Log("Disabling left button");
           buttonLeft.gameObject.SetActive(false);
       }
   }

   public void RefreshInventoryItems() {
       if (itemSlots == null) return;

       // Should only display visible items
       int startIndex = currentPage * 5;

       // Disable right/left buttons first...
       Transform buttonRight = transform.Find("inventoryPageRight");
       if (buttonRight != null)
       {
           Debug.Log("Disabling right button");
           buttonRight.gameObject.SetActive(false);
       }
       Transform buttonLeft = transform.Find("inventoryPageLeft");
       if (buttonLeft != null)
       {
           Debug.Log("Disabling left button");
           buttonLeft.gameObject.SetActive(false);
       }

       // Check if the arrow should be displayed?
       // I'm assuming that only 7 items can be carried at once

       if ( currentPage == 0)
       {
           if (inventory.GetItemListCount() > 5)
           {
               // Display right button
               if (buttonRight != null 
                && !m_Animator.GetCurrentAnimatorStateInfo(0).IsName("UI_close")
                && !m_Animator.GetCurrentAnimatorStateInfo(0).IsName("UI_close_idle"))
               {
                   Debug.Log("Enabling right button");
                   buttonRight.gameObject.SetActive(true);
               }
               else
               {
                    Debug.LogError("Expect right button to exist in UI. Are you sure you named it correctly?");
               }
           }
       }
       else if (currentPage == 1)
       {
           // Display the left button
           if (buttonLeft != null
                && !m_Animator.GetCurrentAnimatorStateInfo(0).IsName("UI_close")
                && !m_Animator.GetCurrentAnimatorStateInfo(0).IsName("UI_close_idle"))
           {
               Debug.Log("Enabling left button");
               buttonLeft.gameObject.SetActive(true);
           }
       }
       else
       {
           Debug.LogError("Unexpected item count in inventory\n");
       }
        for (int i = 0; i < numDisplayedItems; i++)
        {
            if (startIndex + i  < inventory.GetItemListCount())
            {
                // Display appropriate item image in the correct slot
                // get (slot[number] -> image)
                itemSlots[i].GetChild(0).gameObject.SetActive(true);
                Image image = itemSlots[i].GetChild(0).gameObject.GetComponent<Image>();
                image.sprite = inventory.GetItemList()[startIndex + i].GetSprite();
            }
            else
            {   
                // Deactivate image slots with no items in them
                itemSlots[i].GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
