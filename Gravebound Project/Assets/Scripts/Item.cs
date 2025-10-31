using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemObject obj_data;
    public InventoryManager inventory;


    public void PickUp()
    {
        Debug.Log("Picked Up!");
        inventory.AddtoInventory(obj_data);
        Destroy(gameObject);
    }
}
