using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int gold = 0;

    private void Awake()
    {
        instance = this;
    }
}
