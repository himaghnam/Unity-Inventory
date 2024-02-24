using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Inventory Item")]
public class InventoryItem :ScriptableObject
{
    public ItemDataSO ItemData;
    public int StackSize;

    public void UseItem(int amount)
    {

    }
    public int AddItem(int amount)
    {
        StackSize += amount;
        int totalAmount = StackSize;
        if (StackSize > ItemData.maxStack )
        {
            StackSize = ItemData.maxStack;
        }
        return StackSize - totalAmount; // it either returns 0 or negative number
      
    }
    public int DeleteItem(int amount)
    {
        StackSize -= amount;
        return StackSize;
      
    }
}
