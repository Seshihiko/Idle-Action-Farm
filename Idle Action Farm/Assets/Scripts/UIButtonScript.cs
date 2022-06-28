using System;
using System.Collections;
using UnityEngine;

public class UIButtonScript : MonoBehaviour
{
    [SerializeField]private AnimatorScript animCoin;
    public static Action attack; 

    public void Attack()
    {
        attack.Invoke();
    }

    public void OpenPanel(GameObject other)
    {
        other.SetActive(true);
    }

    public void ShowPanel(GameObject other)
    {
        other.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
