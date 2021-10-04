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
        itemsPickedUp = new List<String>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        GameObject dialogueCanvas = GameObject.Find("Dialogue Canvas");
        if (dialogueCanvas != null){
          vars = dialogueCanvas.GetComponent<InMemoryVariableStorage>();
          foreach(string i in itemsPickedUp)
            varSet(i);
        }
    }

    public void setItem(string i){
        string output = "$" + char.ToUpper(i[0]) + i.Substring(1);
        itemsPickedUp.Add(output);
        if (vars != null){
          varSet(output);
        }
    }

    public void setChar(string name){
      string output = "$" + "hasTalkedTo" + name;
      if (vars != null){
        varSet(output);
      }
    }

    private void varSet(string i){
      vars.GetComponent<InMemoryVariableStorage>().SetValue(i, true);
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
