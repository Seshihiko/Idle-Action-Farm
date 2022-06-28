using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private Data data;

    public static float timeToSpawn;
    public static int price;
    public static int maxCountOfItem;
    public static GameObject dropdownItem;
    public static GameObject dropdownParticle;
    public static GameObject itemPrefab;


    private void Awake()
    {
        SetDataItem();
    }

    private void SetDataItem()
    {
        data = (Data)Resources.Load("Grass");

        timeToSpawn = data.timeToSpawn;
        price = data.price;
        maxCountOfItem = data.maxCountOfItem;
        dropdownItem = data.dropdownItem;
        dropdownParticle = data.dropdownParticle;
        itemPrefab = data.itemPrafab;
    }
}
