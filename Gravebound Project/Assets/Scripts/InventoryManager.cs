using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory System/Player Inventory")]
public class InventoryManager : ScriptableObject
{
    public List<InventoryItem> Tupperware = new List<InventoryItem>();
    public GameObject[] slots = new GameObject[12];
    public void AddItem(ItemObject _item)
    {
        GameObject empty = null;
        bool hasItem = false;
        for(int i = 0; i < Tupperware.Count; i++)
        {
            Tupperware.Add(new InventoryItem(_item));
            Tupperware[i] = ItemObject.GetComponent<GameObject>.prefab();
            slots = Tupperware.ToArray();
            //slots[i] = Tupperware[i].ItemObject.prefab;
            Debug.Log("Item is in inventory!");
            //slots[i].GetComponentInChildren<TMP_Text>().text = Tupperware[i].item.name.ToString();
        }
    }
    /*
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
*/
}

public class InventoryItem
{
    public ItemObject item;
    public int stack;
    public InventoryItem(ItemObject items)
    {
        item = items;
        //stack = stacks;
    }
   /* public void AddStack(int value)
    {
        stack += value;
    }
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
    */
}
