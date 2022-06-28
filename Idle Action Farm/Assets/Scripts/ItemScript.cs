using System;
using UnityEngine;
using DG.Tweening;

public class ItemScript : MonoBehaviour
{
    [SerializeField] private float duration;
    [HideInInspector] public bool inBack;

    public static Action toBackpack; //При срабатывание добавляется в рюкзак
   
    private void AddTo()
    {
        if (inBack && BackpackScript.instance.itemCount < DataManager.maxCountOfItem)
        {
            Debug.Log("Добавился");
            toBackpack.Invoke();
            Destroy(gameObject);
        }
        else if (!inBack) Destroy(gameObject);
    }

    public void Raise(Transform target)
    {
        var seq = DOTween.Sequence();

        seq.Append(transform.DOMove(target.position, duration, false));
        seq.OnComplete(AddTo);
    }


}
