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
public class ItemObject : ScriptableObject
{
    public int id;
    public string itemName;
    public itemType type;
    [TextArea(25,20)]
    public string description;
    public GameObject prefab;
}
[CreateAssetMenu(fileName = "Default Item", menuName = "Inventory System/Items/Default")]
public class DefaultObject : ItemObject
{
    //default is like item object
}
[CreateAssetMenu(fileName = "Weapon Item", menuName = "Inventory System/Items/Weapon")]
public class WeaponsObject : ItemObject
{
    public float attackPT;
    public float defensePT;
}
[CreateAssetMenu(fileName = "Puzzle Item", menuName = "Inventory System/Items/Puzzle")]
public class PuzzleObject : ItemObject
{
    public float puzzleNum;
}
[CreateAssetMenu(fileName = "Cassette Item", menuName = "Inventory System/Items/Cassette")]
public class CassetteObject : ItemObject
{
    public int cassetteNum;

}

