using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    
    public Dictionary<Object, InventoryItem> itemDic= new Dictionary<Object, InventoryItem>();
    public List <InventoryItem> inventory = new List<InventoryItem>();

    public void AddtoInventory(Object objectData)
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
    public void RemovefromInventory(Object objectData)
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
    public InventoryItem Get(Object objectData)
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
    public Object data;
    public int stackSize;
    public string name;

    public InventoryItem(Object item)
    {
        data = item;
        data.name = name;
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
