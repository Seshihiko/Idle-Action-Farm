using System;
using System.Collections;
using UnityEngine;

public class BackpackScript : MonoBehaviour
{
    public static BackpackScript instance;

    [SerializeField] private GameObject triggerItem;
    [SerializeField] private GameObject backpackPrefab;// ������
    [SerializeField] private AnimatorScript animation;
    [HideInInspector] public int itemCount; //���������� ��������� � �������

    public static Action sellItem;
    private void Awake()
    {
        instance = this;

        animation = GetComponent<AnimatorScript>();

        ItemScript.toBackpack += AddToBackpack;

        backpackPrefab.GetComponent<MeshRenderer>().enabled = false;
    }

    private void AddToBackpack() //���������� ��������� � ������
    {
        if (itemCount < DataManager.maxCountOfItem)
        {
            backpackPrefab.GetComponent<MeshRenderer>().enabled = true;
            itemCount++;
        }

        FillingVisualization();
    }

    private void FillingVisualization() //��������� ������� ������� � ����������� �� ����������
    {
        float scale = (float)itemCount / DataManager.maxCountOfItem;

        backpackPrefab.transform.localScale = new Vector3(1, scale, 1);

        if (itemCount == DataManager.maxCountOfItem)
        {
            Debug.Log("������ ��������");
            Debug.Log("� ������� " + itemCount);

            animation.SetBool("Full", true);
        }
    }

    private IEnumerator SpawnItem(Transform target)
    {
        triggerItem.SetActive(false);
        Instantiate(DataManager.dropdownItem, transform.position, Quaternion.identity)
            .GetComponent<ItemScript>().Raise(target);

        itemCount--;

        FillingVisualization();

        yield return new WaitForSeconds(0.1f);

        if (itemCount > 0) yield return StartCoroutine(SpawnItem(target));
        else
        {
            backpackPrefab.GetComponent<MeshRenderer>().enabled = false;
            triggerItem.SetActive(true);
            sellItem.Invoke();
            yield break;
        }
    }

    public void ToShop(Transform target) //�������� ��������� � �������
    {
        if(itemCount > 0)
        {
            GameManager.instance.AddItemCount(itemCount);
            animation.SetBool("Full", false);
            StartCoroutine(SpawnItem(target));
        }
    }
}
