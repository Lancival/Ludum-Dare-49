using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
   [SerializeField] private Canvas canvas;
   private RectTransform m_DraggingPlane;
   private GameObject m_DraggingIcon;

   private void Awake()
   {
       m_DraggingPlane = transform as RectTransform;
       m_DraggingIcon = this.gameObject;
   }
   public void OnBeginDrag(PointerEventData eventData)
   {
       Debug.Log("OnBeginDrag");
   }
   public void OnDrag(PointerEventData eventData)
   {
       Debug.Log("OnDrag");
       //rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
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
   }   
   public void OnPointerDown(PointerEventData eventData)
   {
       Debug.Log("OnPointerDown");
   }
}
