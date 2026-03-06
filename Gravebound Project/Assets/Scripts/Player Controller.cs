using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour 
{

    public InventoryManage inventory;
    public InventoryMenu ui;
    public float Obj_Distance; 
    public float maxDistance; 

    public LayerMask inventItem;
    public LayerMask puzzle;

    public CassettePlayer cassettePlayer;

    private Material ogMat;
    private Transform highlight;
    private Transform selection;
    public Material highlighter;

    public StatueBody statue;

    // Update is called once per frame
    void Update() 
    { 
        if(highlight != null)
        {
            highlight.GetComponentInChildren<MeshRenderer>().material = ogMat;
            highlight = null;
        }
        Ray lookPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit looking;
        if(Physics.Raycast(lookPoint, out looking))
        {
            highlight = looking.transform;
            if(highlight.CompareTag("Select") && highlight != selection)
            {
                if(highlight.GetComponentInChildren<MeshRenderer>().material != highlighter)
                {
                    ogMat = highlight.GetComponentInChildren<MeshRenderer>().material;
                    highlight.GetComponentInChildren<MeshRenderer>().material = highlighter;
                }
            }
            else
            {
                highlight = null;
            }
        }
        if (Input.GetButtonDown("Interact")) 
        { 
            Ray clickPoint = Camera.main.ScreenPointToRay(Input.mousePosition); 
            RaycastHit touch;
            if (Physics.Raycast(clickPoint, out touch, maxDistance, inventItem)) 
            {
                Obj_Distance = touch.distance; 
                Item _item = touch.collider.gameObject.GetComponent<Item>();
                Debug.Log(_item.name);
                inventory.AddItem(_item.item); 
                Destroy(touch.collider.gameObject);
                Debug.Log("Item picked up "+ _item.name); 

                
               if (cassettePlayer != null && _item.item.itemName == "Cassette Tape")
               {
                    cassettePlayer.InsertCassette(_item);
               }
                
            }
            if(Physics.Raycast(clickPoint, out touch, puzzle))
            {
                if(statue.interact == true)
                {
                    statue.placement();
                    Debug.Log("placing head...");
                }
            }

        } 
    } 
}