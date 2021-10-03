using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
   public enum ItemType {
       Item1,
       Item2,
       Item3,
       Item4,
       Item5,
   }
   
   public ItemType itemType;
   public int amount;
}
