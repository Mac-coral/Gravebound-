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
    public GameObject inventoryMenu;
    public InventoryManage inventory;
    public GameObject[] slots;
    GameObject currentSelect;
    public List<ItemObject> itemsDisplay;
    int selection;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        isOpen = false;
        inventory = Player.GetComponent<InventoryManage>();
        itemsDisplay = new List<ItemObject>(inventory.Tupperware);
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
        Display();
    }

    void enableInventory()
    {
        inventoryMenu.SetActive(true);
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Display();
    }

    void disableInventory()
    {
        inventoryMenu.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Display()
    {
        for (int i = 0; i < itemsDisplay.Count; i++)
        {
            int tupperitems = inventory.Tupperware.Count;
            if (itemsDisplay[i] != null && i <= tupperitems)
            {
                slots[i].GetComponentInChildren<TMP_Text>().text = itemsDisplay[i].itemName.ToString();
            }
            else
            {
                itemsDisplay.Add(inventory.Tupperware[i]);
            }
        }

    }
    public void DeselectSlots()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
