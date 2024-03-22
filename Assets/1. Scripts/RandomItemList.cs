using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemList : MonoBehaviour
{
    public static RandomItemList instance { get; private set; }

    public List<Item> items;

    private void Awake()
    {
        instance = this;
    }
}
