using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    
    public Dictionary<ItemObject, InventoryItem> itemDic= new Dictionary<ItemObject, InventoryItem>();
    public List <InventoryItem> inventory = new List<InventoryItem>();

    public void AddtoInventory(ItemObject objectData)
    { 
        if(itemDic.TryGetValue(objectData, out InventoryItem value))
        {
            value.AddStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(objectData);
            inventory.Add(newItem);
            itemDic.Add(objectData, newItem);
        }
    }
    public void RemovefromInventory(ItemObject objectData)
    {
        if(itemDic.TryGetValue(objectData,out InventoryItem value))
        {
            value.RemoveStack();
            if(value.stackSize == 0)
            {
                inventory.Remove(value);
                itemDic.Remove(objectData);
            }
        }
    }
    public InventoryItem Get(ItemObject objectData)
    {
        if(itemDic.TryGetValue(objectData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }

}

public class InventoryItem
{
    public ItemObject data;
    public int stackSize;
    public string itemName;

    public InventoryItem(ItemObject item)
    {
        data = item;
        itemName = data.itemName;
        AddStack();
    }
    public void AddStack()
    {
        stackSize++;
    }
    public void RemoveStack()
    {
        stackSize--;
    }

}
