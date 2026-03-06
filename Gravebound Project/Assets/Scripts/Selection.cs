using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Selection : MonoBehaviour, IPointerClickHandler
{
    public GameObject Selecter;
    private InventoryMenu manager;
    public bool selected;
    public bool isEquipped;

    public GameObject equipItem;
    public GameObject unequipItem;

    GameObject player;
    public GameObject hand;
    GameObject selecterOn;
    GameObject selectedObject;
    public static GameObject currentItem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        manager = GameObject.Find("Menus").GetComponent<InventoryMenu>();
        equipItem.GetComponent<Button>().enabled = false;
        hand = GameObject.Find("Player").transform.GetChild(2).gameObject;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        //Selection.currentItem;
    }

    public void OnPointerClick(PointerEventData ped)
    {
        if(ped.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
    }

    public void OnLeftClick()
    {
        manager.DeselectSlots();
        Selecter.SetActive(true);
        selected = true;
        if (selected)
        {
            equipItem.GetComponent<Button>().enabled = true;
            if (selected && isEquipped)
            {
                Debug.Log("Already equipped!");
            }
        }
    }

    public void equip()
    {
        for (int i = 0; i < manager.slots.Length; i++)
        {
            bool isActive = manager.slots[i].gameObject.transform.GetChild(1).gameObject.activeSelf;
            if (isActive == true)
            {
                selecterOn = manager.slots[i].gameObject.transform.GetChild(1).gameObject;
                Debug.Log(selecterOn.name);
                selectedObject = selecterOn;
                selectedObject = manager.itemsDisplay[i].prefab;
            }
        }
        Debug.Log(selectedObject.name);
        currentItem = Instantiate(selectedObject, hand.transform.position,Quaternion.identity);
        Debug.Log("Object in hand!");
        //equipItems.Add(currentItem);
        isEquipped = true;
    }
    
    public void unequip()
    {
        Debug.Log(Selection.currentItem.name);
        Destroy(Selection.currentItem);
        Debug.Log("Item back in Inventory!");
    }
}
