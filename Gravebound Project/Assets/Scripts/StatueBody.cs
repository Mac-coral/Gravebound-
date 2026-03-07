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
    public Selection selector;
    public GameObject MazeDoor;

    public bool interact;

    public static GameObject testingHead;

    public GameObject Head;

    int matchingID = 9;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        testingHead = null;
    }
    
    // Update is called once per frame
    void Update()
    {

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
                interact = true;
            }
        }
    }

    void OnTriggerExit(Collider otherCollider)
    {
        interact = false;
    }

    void doorOpen()
    {
        if (matchingPiece)
        {
            StartCoroutine(LowerGate());
            Debug.Log("Lowering Gate!");
        }
    }

    void RightOrWrong()
    {
        if(testingHead != null)
        {
            Debug.Log("Matching...");
            if(testingHead.GetComponent<Item>().item.id != matchingID)
            {
                Debug.Log("Not matching!");
                Destroy(testingHead);
            }
            if (testingHead.GetComponent<Item>().item.id == matchingID)
            {
                Debug.Log("Matching!");
                matchingPiece = true;
                doorOpen();
            }
        }

    }

    public void placement()
    {
        Debug.Log(Selection.currentItem);
        testingHead = Instantiate(Selection.currentItem, Head.transform.position, Quaternion.identity);
        selector.unequip();
        RightOrWrong();
    }

    IEnumerator LowerGate()
    {
        Vector3 startPos = MazeDoor.transform.position;
        Debug.Log(startPos);
        Vector3 endPos = startPos + (Vector3.down * 25f);
        Debug.Log(endPos);
        float duration = 3f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            MazeDoor.transform.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
            elapsed += Time.deltaTime;
            Debug.Log("Door down!");
            yield return null;
        }

        MazeDoor.transform.position = endPos;
    }
}
