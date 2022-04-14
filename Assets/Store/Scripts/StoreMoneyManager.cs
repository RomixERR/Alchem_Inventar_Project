using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreMoneyManager : MonoBehaviour
{
    public int MaxAmountWillBuy = 100;
    public static int MaxAmountWillBuyStatic;
    public Text MoneyText;
    
    /// <summary>
    /// Количесво денег у игрока
    /// </summary>
    public static int Money;
    /// <summary>
    /// Кол-во предметов у игрока
    /// </summary>
    public static int[] CountOfItem = new int[8];

    public static int  CalculateSellCost(int cost)
    {
        return cost / 2;
    }

    //public static bool CanYouBuy(int cost)
    //{
    //    if (cost <= Money) {
    //        return true;
    //    } else { return false; }
    //}

    //public static bool CanYouSell(int ItemIndex)
    //{
    //    if (CountOfItem[ItemIndex] > 0) {
    //        return true;
    //    } else { return false; }
    //}

    public static int CanYouBuy(int cost)
    {
        int amount=0;
        if (cost > 0) { amount = Money / cost; } else { amount = MaxAmountWillBuyStatic;}
        return amount;
    }

    public static int CanYouSell(int ItemIndex)
    {
        return CountOfItem[ItemIndex];
    }


    public static void Buy(int BuyCost, int ItemIndex, int amount=1)
    {
        if ((BuyCost * amount) <= Money)
        {
            Money -= BuyCost * amount;
            CountOfItem[ItemIndex]+= amount;
        }
    }

    public static void Sell(int SellCost, int ItemIndex, int amount = 1)
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
        MaxAmountWillBuyStatic = MaxAmountWillBuy;
    }

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = Money.ToString();
    }
}


