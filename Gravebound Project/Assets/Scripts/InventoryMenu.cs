using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryMenu : MonoBehaviour
{
    bool isOpen;
    public GameObject inventPrefab;
    public Canvas inventoryMenu;
    public InventoryManager inventory;
    List<InventoryItem> itemsDisplay = new List<InventoryItem>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(isOpen)
            {
                disableInventory();
                isOpen = false;
            }
            else
            {
                enableInventory();
                isOpen = true;
            }
        }
        UpdateDisplay();
    }

    void enableInventory()
    {
        inventoryMenu.enabled = true;
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Display();
    }

    void disableInventory()
    {
        inventoryMenu.enabled = false;
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Display()
    {
        int length = inventory.slots.Length;
        for(int i = 0; i < length; i++)
        {
            inventory.slots[i].GetComponentInChildren<TMP_Text>().text = inventory.Tupperware[i].item.name.ToString();
        }
    }

    void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Tupperware.Count; i++)
        {
            int tupperitems = inventory.Tupperware.Count;
            if (itemsDisplay[i] != null)
            {
                inventory.slots[i].GetComponentInChildren<TMP_Text>().text = inventory.Tupperware[i].item.name.ToString();
            }
            else
            {
                itemsDisplay.Add(inventory.Tupperware[i]);
            }
        }
    }
    
}
