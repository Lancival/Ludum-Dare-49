using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
   public static ItemAssets Instance { get; private set; }

   private void Awake() {
       Instance = this;
   }

/* Add item sprites here */
   public Sprite item1_Sprite;
   public Sprite item2_Sprite;
   public Sprite item3_Sprite;
   public Sprite item4_Sprite;
   public Sprite item5_Sprite;
}
