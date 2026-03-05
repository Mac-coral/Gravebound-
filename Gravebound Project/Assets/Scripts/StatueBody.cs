using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StatueBody : MonoBehaviour
{
    
    public InventoryManage playerInventory;
    public GameObject player;
    public GameObject statueBody;
    public bool matchingPiece;
    private List<ItemObject> itemsList;

    public bool interact;

    GameObject Head;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //check to see if the bool is true
        if (matchingPiece)
        {
            doorOpen();
        }
    }

    void OnTriggerEnter(Collider otherCollider)
    {
        Debug.Log("Can Interact");
        itemsList = player.GetComponent<InventoryManage>().Tupperware;
        //search inventory for statue head, if so, alert player to place head on the statue
        for (int i = 0; i < itemsList.Count; i++)
        {
            string objName = itemsList[i].itemName;
            if(objName == "Statue Head")
            {
                interact = true; break;
            }
        }
    }

    void OnTriggerExit(Collider otherCollider)
    {
        interact = false;
    }

    void doorOpen()
    {
        //if bool is true, trigger event
    }

    void RightOrWrong()
    {
        //checks item information to see if matching (use id number)
    }

    public void placement()
    {
        //
    }
    
}
