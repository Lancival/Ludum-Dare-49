using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
   private RectTransform m_DraggingPlane;
   private GameObject m_DraggingIcon;
   private Vector2 m_InitialPosition;
   [SerializeField] private CanvasGroup canvasGroup;

   private void Awake()
   {
       canvasGroup = GetComponent<CanvasGroup>();
       m_DraggingPlane = transform as RectTransform;
       m_DraggingIcon = this.gameObject;
       m_InitialPosition = GetComponent<RectTransform>().anchoredPosition;
   }
   public void OnBeginDrag(PointerEventData eventData)
   {
       Debug.Log("OnBeginDrag");
       canvasGroup.alpha = 0.5f;
       canvasGroup.blocksRaycasts = false;
   }
   public void OnDrag(PointerEventData eventData)
   {
       Debug.Log("OnDrag");
       var rt = m_DraggingIcon.GetComponent<RectTransform>();
       Vector3 globalMousePos;
       if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlane, eventData.position, eventData.pressEventCamera, out globalMousePos))
       {
           rt.position = globalMousePos;
           rt.rotation = m_DraggingPlane.rotation;
       }
   }
   public void OnEndDrag(PointerEventData eventData)
   {
       Debug.Log("OnEndDrag");

       var rt = m_DraggingIcon.GetComponent<RectTransform>();
       rt.anchoredPosition = m_InitialPosition;
       canvasGroup.alpha = 1.0f;
       canvasGroup.blocksRaycasts = true;
   }
   public void OnPointerDown(PointerEventData eventData)
   {
       Debug.Log("OnPointerDown");
   }
}
