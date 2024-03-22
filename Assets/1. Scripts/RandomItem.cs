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

    private void Crash(Collider collison)
    {
        switch (randomItem.itemType)
        {
            case ItemType.Gold_100:
            case ItemType.Gold_500:
            case ItemType.Gold_1000:
                GameManager.instance.gold += randomItem.itemValue;
                break;
            case ItemType.Small_SpeedUp:
            case ItemType.Big_SpeedUp:
                collison.gameObject.GetComponentInParent<CarController>().BoosterInit(randomItem.itemValue);
                break;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Car"))
        {
            Crash(collision);
            gameObject.SetActive(false);
        }
    }
}
