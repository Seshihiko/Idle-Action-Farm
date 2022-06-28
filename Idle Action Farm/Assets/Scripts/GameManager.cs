using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private AnimatorScript animatorCoin;
    [SerializeField] private Text coinText;

    private int coin;
    private int itemForSale;

    private void Awake()
    {
        instance = this;
        BackpackScript.sellItem += SellItem;
    }

    private void SellItem()
    {
        animatorCoin.SetTrigger("Play");
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(CoinCounter());
    }
    private IEnumerator CoinCounter()
    {
        coin += DataManager.price;
        coinText.text = "" + coin;

        itemForSale--;

        yield return new WaitForSeconds(0.05f);

        if (itemForSale > 0) yield return StartCoroutine(CoinCounter());
        else
        {
            yield break;
        }
    }

    public void AddItemCount(int count)
    {
        itemForSale = count;
    }
}
