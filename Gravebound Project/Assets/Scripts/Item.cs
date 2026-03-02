using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public static Item instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public ItemObject item;
}
