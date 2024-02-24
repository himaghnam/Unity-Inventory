using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Inventory : MonoBehaviour
{   
    [SerializeField]
    public ItemDataSO item;
    public ItemDataSO item2;
    public ItemDataSO item3;
    public List<InventoryItem> InventoryList = new();
    // Start is called before the first frame update
    public void Start()
    { 
        AddInventoryItem(item);
        AddInventoryItem(item2);
        AddInventoryItem(item3);

        // DeleteInventoryItem(item,3);
     //  InventoryList = new List<ItemDataSO>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddInventoryItem(ItemDataSO newitem)
    {   
        int amount= newitem.amount;

        if (newitem.stackable == true)
        {   
            while (amount>0)
            {   
                for(int i= 0; i < InventoryList.Count; i++)
                {
                    if (InventoryList[i].ItemData.id == newitem.id && InventoryList[i].StackSize < newitem.maxStack)
                    {   
                        int leftCount = InventoryList[i].AddItem(amount);
                        Debug.Log(leftCount);
                        if ( leftCount < 0)
                        {   
                            amount = Math.Abs(leftCount);
                            continue;
                        }
                        return;
                    }
                }

                InventoryItem item = new();
                item.name = newitem.displayName;
                item.ItemData = newitem;

                if (amount < newitem.maxStack)
                {
                    item.StackSize = amount;
                    InventoryList.Add(item);
                    amount = 0;
                }
                else
                {
                    item.StackSize = newitem.maxStack;
                    InventoryList.Add(item); 
                    amount -= newitem.maxStack;
                }

            }
        }
        else
        {
            InventoryItem item = new();
            item.name = newitem.displayName;
            item.ItemData = newitem;
            item.StackSize = 1;
            InventoryList.Add(item);
        }
    }
    public void DeleteInventoryItem(ItemDataSO item,int amount)
    {
        for(int i = InventoryList.Count-1; i>=0; i--)
        {
            if (InventoryList[i].ItemData.id == item.id)
            {   
                int leftCount = InventoryList[i].DeleteItem(amount);
                if ( leftCount < 0)
                {   Debug.Log(leftCount);
                    InventoryList.RemoveAt(i);
                    DeleteInventoryItem(item, Math.Abs(leftCount));
                    return;
                }
                else if(leftCount == 0)
                {   Debug.Log(leftCount);
                    InventoryList.RemoveAt(i);
                    return;
                }
                return;
            }
        }
    }
}
