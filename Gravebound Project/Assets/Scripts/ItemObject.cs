using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum itemType
{
    Weapons,
    puzzlePiece,
    Default,
    cassetteTape
}
[CreateAssetMenu(fileName = "Item", menuName = "Inventory System/Items")]
public class ItemObject : ScriptableObject
{
    public int id;
    public string itemName;
    public itemType type;
    [TextArea(25, 20)]
    public string description;
    public GameObject prefab;
    public Image itemImage;
}
