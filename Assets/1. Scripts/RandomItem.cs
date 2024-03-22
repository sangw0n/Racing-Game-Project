using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    public Item randomItem;

    private Renderer rdr;

    private void Awake()
    {
        rdr = GetComponent<Renderer>();
    }

    private void Start()
    {
        int index = Random.Range(0, RandomItemList.instance.items.Count);

        randomItem = RandomItemList.instance.items[index];
        rdr.material.color = randomItem.color;
    }
}
