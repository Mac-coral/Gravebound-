using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Object", menuName = "Scriptable Object/Object")]
public class Object : ScriptableObject
{
    public string name;
    public string description;
    public Sprite icon;
    public GameObject prefab;
}
