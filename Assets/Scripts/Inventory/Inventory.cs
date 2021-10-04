using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

// Add this to the player
public class Inventory
{
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;
    private List<string> itemsPickedUp;
    private List<string> chars;
    private InMemoryVariableStorage vars;

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
        itemsPickedUp = new List<string>();
        chars = new List<string>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        GameObject dialogueCanvas = GameObject.Find("Dialogue Canvas");
        if (dialogueCanvas != null){
          Debug.Log("dialogueCanvas found");
          vars = dialogueCanvas.GetComponent<InMemoryVariableStorage>();
          foreach(string i in itemsPickedUp)
            varSet(i);
          foreach(string i in chars)
            varSet(i);
          printitems();
        }else{

            Debug.Log("dialogueCanvas not found");
        }
    }
    public void printitems(){
      if(vars == null)
        Debug.Log("vars not set");
      else
        foreach(var i in vars)
          Debug.Log(i);
    }

    public List<string> GetItemsPickedUp()
    {
      return itemsPickedUp;
    }

    public List<string> GetCharsTalkedTo(){
      return chars;
    }
    public void setItem(string i){
        itemsPickedUp.Add(i);
        if (vars != null){
          varSet(i);
        }
    }
    public void setChar(string i){
      chars.Add(i);
    }

    private void varSet(string i){
      vars.SetValue(i, true);
    }

    public void AddItem(Item item) {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);

        AudioItemPickupSingleton.instance.GetComponent<AudioPlayOneShot>().Play();
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
