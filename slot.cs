using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour,IPointerClickHandler,IBeginDragHandler,IDragHandler,IEndDragHandler,IDropHandler
{
    public Image SpriteCanvas;
    public Image SelectedImageCanvas;
    public TMP_Text amount;
    public int index;

    public InventoryUI inventoryUI;
    public void OnBeginDrag(PointerEventData eventData)
    {
        inventoryUI.DeselectSlots();
        SelectedImageCanvas.enabled = true;
        SpriteCanvas.transform.SetParent(transform.root);
        SpriteCanvas.raycastTarget = false;
        inventoryUI.lastSelectedSlot = index;
    }

    public void OnDrag(PointerEventData eventData)
    {
        SpriteCanvas.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        SpriteCanvas.raycastTarget = true;
        SpriteCanvas.transform.SetParent(this.transform);
        SpriteCanvas.transform.SetSiblingIndex(1);
        SpriteCanvas.rectTransform.anchoredPosition3D = new Vector3(0,0,0);

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            inventoryUI.DeselectSlots();
            SelectedImageCanvas.enabled = true;
            inventoryUI.lastSelectedSlot = index;
        }
    }

   public void OnDrop(PointerEventData eventData)
    {
        // Debug.Log(index);
        inventoryUI.OnDragableDrop(index);
    }
}
