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

   public Sprite GetSprite()
   {
    switch(itemType)
    {
        default:
        case ItemType.Item1:    return ItemAssets.Instance.item1_Sprite;
        case ItemType.Item2:    return ItemAssets.Instance.item2_Sprite;
        case ItemType.Item3:    return ItemAssets.Instance.item3_Sprite;
        case ItemType.Item4:    return ItemAssets.Instance.item4_Sprite;
        case ItemType.Item5:    return ItemAssets.Instance.item5_Sprite;
    }
   }
}
