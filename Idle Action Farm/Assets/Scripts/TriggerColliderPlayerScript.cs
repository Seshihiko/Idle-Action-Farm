using System;
using UnityEngine;

public class TriggerColliderPlayerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item") && BackpackScript.instance.itemCount < DataManager.maxCountOfItem)
        {
            other.GetComponent<ItemScript>().Raise(transform);
            other.GetComponent<ItemScript>().inBack = true;
        }
        else if (other.CompareTag("Shop")) BackpackScript.instance.ToShop(other.transform);
    }
}
