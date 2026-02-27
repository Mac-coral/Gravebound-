using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public InventoryManager inventory;
    public float Obj_Distance; 
    public float maxDistance; 

    public LayerMask inventItem;

    public CassettePlayer cassettePlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() 
    { 

    } 

    // Update is called once per frame
    void Update() 
    { 
        if(Input.GetButtonDown("Interact")) 
        { 
            Ray clickPoint = Camera.main.ScreenPointToRay(Input.mousePosition); 
            RaycastHit touch;
            if (Physics.Raycast(clickPoint, out touch, maxDistance, inventItem)) 
            { 
                Obj_Distance = touch.distance; 
                Item item = touch.collider.gameObject.GetComponent<Item>();
                inventory.AddItem(item.item);
                Destroy(item.gameObject);
                Debug.Log("Item picked up "+ item.name); 


               if (cassettePlayer != null && item.CompareTag("Cassette Tape"))
               {
                    cassettePlayer.InsertCassette(item);
               }
            } 
        } 
    } 
}