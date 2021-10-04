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
   public Sprite book_outline_Sprite;
   public Sprite businessCard_outline_Sprite;
   public Sprite cables_outline_Sprite;
   public Sprite key_outline_Sprite;
   public Sprite ladder_outline_Sprite;
   public Sprite paints_outline_Sprite;
   public Sprite rotaryhelm_outline_Sprite;
   public Sprite sketchbook_outline_Sprite;
   public Sprite steeringwheel_outline_Sprite;
   public Sprite suitcase_outline_Sprite;
   public Sprite travelbook_outline_Sprite;
}
