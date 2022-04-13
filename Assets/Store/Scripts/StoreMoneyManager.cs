using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreMoneyManager : MonoBehaviour
{
    public Text MoneyText;
    
    /// <summary>
    /// Количесво денег у игрока
    /// </summary>
    public static int Money;
    /// <summary>
    /// Кол-во предметов у игрока
    /// </summary>
    public static int[] CountOfItem = new int[8]; 


    public bool CanYouBuy(int cost)
    {
        if (cost <= Money) return true; else return false;
    }

    public bool CanYouSell(int ItemIndex)
    {
        if (CountOfItem[ItemIndex] > 0) return true; else return false;
    }

    public void Buy(int BuyCost, int ItemIndex, int amount=1)
    {
        if ((BuyCost * amount) <= Money)
        {
            Money -= BuyCost * amount;
            CountOfItem[ItemIndex]+= amount;
        }
    }

    public void Sell(int SellCost, int ItemIndex, int amount = 1)
    {
        if (CountOfItem[ItemIndex]>= amount)
        {
            Money += SellCost * amount;
            CountOfItem[ItemIndex] -= amount;
        }
    }





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = Money.ToString();
    }
}


