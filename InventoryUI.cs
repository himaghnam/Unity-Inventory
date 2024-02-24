using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUI : MonoBehaviour
{   
    public GameObject MenuUI;
    public GameObject SlotUI;
    public Inventory Inventory;
    // public Slot SlotPrefab;
    // public Transform SlotsUI;
    private bool menuActivated;
    public Slot[] Slots;
    [HideInInspector]
    public int lastSelectedSlot;
    // Start is called before the first frame update
    void Start()
    {
        menuActivated = MenuUI.activeSelf;
        UpdateUI();
        for (int i = 0; i < Slots.Length; i++) // assign inventoryUI to all slots
        {
            Slots[i].inventoryUI = this;
            Slots[i].index = i;
        }
        // for (int i = 0; i < 20; i++)
        // {
        //     Instantiate(SlotPrefab).transform.parent = SlotsUI;
        //     Slots[i] = SlotPrefab;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            MenuUI.SetActive(true);
            menuActivated = true;
        }
        else if (Input.GetButtonDown("Inventory") && menuActivated)
        {
            MenuUI.SetActive(false);
            menuActivated = false;
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < Inventory.InventoryList.Count; i++)
        {   
            Slots[i].SpriteCanvas.sprite = Inventory.InventoryList[i].ItemData.icon;
            if (Inventory.InventoryList[i].ItemData.stackable)
            {
                Slots[i].amount.enabled = true;
                Slots[i].amount.text = Inventory.InventoryList[i].StackSize.ToString();
            }
            else{
                Slots[i].amount.enabled = false;
            }
        }
    }
    private void UpdateSlots()
    {
        for (int i = 0; i < Slots.Length; i++) // assign inventoryUI to all slots
        {
            Slots[i].index = i;
            Slots[i].SpriteCanvas.sprite = null;
            Slots[i].amount.enabled = false;
        }
    }
    public void DeselectSlots() 
    {
        Slots[lastSelectedSlot].SelectedImageCanvas.enabled = false;
        // for (int i = 0; i < Slots.Length; i++)
        // {
        //     Slots[i].SelectedImageCanvas.enabled = false;
        // }
    }

     public void OnDragableDrop(int dropped_index)
    {   
        DeselectSlots();
        
        Slot slot1 = Slots[lastSelectedSlot];
        Slots[lastSelectedSlot]= Slots[dropped_index];
        Slots[dropped_index] = slot1;
        
        UpdateSlots();
        UpdateUI();
        
    }
}
