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

    public GameObject ScrollListOfItems;

    

    [Header("Avtoset from StoreitemScript fields")]
    public int BuyCost;
    public int SellCost;
    public int SiblingIndex;
    public bool NowCanBuy = true;
    public bool NowCanSell = true;
    public int Amount;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StoreMoneyManager.CanYouBuy(BuyCost) > 0) NowCanBuy = true; else NowCanBuy = false;
        if (StoreMoneyManager.CanYouSell(SiblingIndex) > 0) NowCanSell = true; else NowCanSell = false;

        string B, C, C2;

        Amount = StoreMoneyManager.CountOfItem[SiblingIndex];

        if (NowCanBuy)
        {
            B = $"Buy for {BuyCost}$";
            LinkedButtonBuy.enabled = true;
        }
        else
        {
            B = "Can't be bought";
            LinkedButtonBuy.enabled = false;
        }
        if (NowCanSell)
        {
            C = $"Sell for {SellCost}$, you have {Amount}";
            C2 = $"Sell for {SellCost}$";
            LinkedButtonSell.enabled = true;
        }
        else
        {
            C = "Cannot be sold";
            C2 = C;
            LinkedButtonSell.enabled = false;
        }

        LinkedTextCost.text = B + System.Environment.NewLine + C;
        LinkedButtonTextBuy.text = B;
        LinkedButtonTextSell.text = C2;
        
    }
}
