using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryMenu : MonoBehaviour
{
    bool isOpen;
    public GameObject Player;
    public Canvas inventoryMenu;
    public InventoryManage inventory;
    public Image[] slots;
    GameObject currentSelect;
    public List<ItemObject> itemsDisplay;
    int selected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isOpen = false;
        inventory = Player.GetComponent<InventoryManage>();
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
        //selection();
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
        int length = slots.Length;
        for(int i = 0; i < length; i++)
        {
            slots[i].GetComponentInChildren<TMP_Text>().text = inventory.Tupperware[i].name.ToString();
        }
    }

    void UpdateDisplay()
    {
        //itemsDisplay = inventory.returnInventory();
        for (int i = 0; i < inventory.Tupperware.Count; i++)
        {
            int tupperitems = inventory.Tupperware.Count;
            if (itemsDisplay[i] != null && i > tupperitems)
            {
                slots[i].GetComponentInChildren<TMP_Text>().text = inventory.Tupperware[i].name.ToString();
            }
            else
            {
                itemsDisplay.Add(inventory.Tupperware[i]);
            }
        }
    }
 /*   
    public void selection()
    {
        if (selected > itemsDisplay.Count - 1)
        {
            selected = 0;
        }
        if (selected < 0)
        {
            selected = itemsDisplay.Count - 1;
        }
        currentSelect = itemsDisplay[selected].prefab;
    }
 */
}
