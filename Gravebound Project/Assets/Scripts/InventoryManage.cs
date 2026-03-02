using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManage : MonoBehaviour
{
    public List<ItemObject> Tupperware = new List<ItemObject>();
    int InventIndex = 12;

    public void AddItem(ItemObject _item)
    {
        bool inInventory = true;
        InventIndex = Tupperware.Count;
        for (int i = 0; i < InventIndex; i++)
        {
            if (Tupperware[i] == _item)
            {
                Debug.Log("In Inventory Already!");
                inInventory = true;
                break;
            }
        }
        if (!inInventory)
        {
            Tupperware.Add(_item);
            Debug.Log("Item is in inventory!");
        }
    }

    public void RemoveItem()
    {
        //will remove an item when it is used
    }

    public List<ItemObject> returnInventory()
    {
        return Tupperware;
    }
}

