using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreBuyOrSellScript : MonoBehaviour
{
    [Header("Link fields")]
    public Image LinkedImage;
    public Text LinkedTextItemName;
    public Text LinkedTextCost;
    public Text LinkedButtonTextBuy;
    public Text LinkedButtonTextSell;
    public Button LinkedButtonBuy;
    public Button LinkedButtonSell;

    public Button LinkedButtonBuyPlus;
    public Text LinkedTextBuyAmount;
    public Button LinkedButtonBuyMinus;

    public Button LinkedButtonSellPlus;
    public Text LinkedTextSellAmount;
    public Button LinkedButtonSellMinus;


    public GameObject ScrollListOfItems;


    

    [Header("Avtoset from StoreitemScript fields")]
    public int BuyCost;
    public int SellCost;
    public int SiblingIndex;
    public bool NowCanBuy = true;
    public bool NowCanSell = true;
    public int Amount;

    public int AmountSell;
    public int AmountBuy;

    private int SellCount;
    private int BuyCount;

    private void  OnPressBuyPlus()
    {
        BuyCount++;
        if (BuyCount > AmountBuy) BuyCount = AmountBuy;

    }
    private void OnPressBuyMinus()
    {
        BuyCount--;
        if (BuyCount < 0) BuyCount = 0;
    }
    private void OnPressSellPlus()
    {
        SellCount++;
        if (SellCount > AmountSell) SellCount = AmountSell;
    }
    private void OnPressSellMinus()
    {
        SellCount--;
        if (SellCount < 0) SellCount = 0;
    }

    private void OnPressBuy()
    {
        if (BuyCount > 0)
        {
            StoreMoneyManager.Buy(BuyCost, SiblingIndex, BuyCount);
        }
        gameObject.SetActive(false);
    }

    private void OnPressSell()
    {
        if (SellCount > 0)
        {
            StoreMoneyManager.Sell(SellCost, SiblingIndex, SellCount);
        }
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    private void Start()
    {
        LinkedButtonBuyPlus.onClick.AddListener(OnPressBuyPlus);
        LinkedButtonBuyMinus.onClick.AddListener(OnPressBuyMinus);
        LinkedButtonSellPlus.onClick.AddListener(OnPressSellPlus);
        LinkedButtonSellMinus.onClick.AddListener(OnPressSellMinus);
        LinkedButtonBuy.onClick.AddListener(OnPressBuy);
        LinkedButtonSell.onClick.AddListener(OnPressSell);
    }

    public void Initial()
    {
        string B, C, C2,B2;

        Amount = StoreMoneyManager.CountOfItem[SiblingIndex];


        if (NowCanBuy)
        {
            B = $"Buy for {BuyCost}$";
            B2 = $"Buy for {BuyCost * BuyCount}$";
            LinkedButtonBuy.enabled = true;
            BuyCount = 1;
        }
        else
        {
            B = "Can't be bought";
            B2 = B;
            LinkedButtonBuy.enabled = false;
            BuyCount = 0;
        }
        if (NowCanSell)
        {
            C = $"Sell for {SellCost}$, you have {Amount}";
            C2 = $"Sell for {SellCost * SellCount}$";
            LinkedButtonSell.enabled = true;
            SellCount = 1;
        }
        else
        {
            C = "Cannot be sold";
            C2 = C;
            LinkedButtonSell.enabled = false;
            SellCount = 0;
        }

        LinkedTextCost.text = B + System.Environment.NewLine + C;
        LinkedButtonTextBuy.text = B2;
        LinkedButtonTextSell.text = C2;
    }


    // Update is called once per frame
    void Update()
    {
        LinkedTextBuyAmount.text = BuyCount.ToString();
        LinkedTextSellAmount.text = SellCount.ToString();
    }
}
