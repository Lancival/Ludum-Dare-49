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
       Item6,
       Item7,
       Item8,
       Item9,
       Item10,
       Item11
   }
   
   public ItemType itemType;
   public int amount;

   public Sprite GetSprite()
   {
    switch(itemType)
    {
        default:
        case ItemType.Item1:    return ItemAssets.Instance.book_outline_Sprite;
        case ItemType.Item2:    return ItemAssets.Instance.businessCard_outline_Sprite;
        case ItemType.Item3:    return ItemAssets.Instance.cables_outline_Sprite;
        case ItemType.Item4:    return ItemAssets.Instance.key_outline_Sprite;
        case ItemType.Item5:    return ItemAssets.Instance.ladder_outline_Sprite;
        case ItemType.Item6:    return ItemAssets.Instance.paints_outline_Sprite;
        case ItemType.Item7:    return ItemAssets.Instance.rotaryhelm_outline_Sprite;
        case ItemType.Item8:    return ItemAssets.Instance.sketchbook_outline_Sprite;
        case ItemType.Item9:    return ItemAssets.Instance.steeringwheel_outline_Sprite;
        case ItemType.Item10:   return ItemAssets.Instance.suitcase_outline_Sprite;
        case ItemType.Item11:   return ItemAssets.Instance.travelbook_outline_Sprite;
    }
   }
}
