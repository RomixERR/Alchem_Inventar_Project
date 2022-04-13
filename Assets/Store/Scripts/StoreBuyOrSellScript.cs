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
    public bool NowCanBuy = true;
    public bool NowCanSell = true;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string B, C;

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
            C = $"Sell for {SellCost}$";
            LinkedButtonSell.enabled = true;
        }
        else
        {
            C = "Cannot be sold";
            LinkedButtonSell.enabled = false;
        }


        LinkedButtonTextBuy.text = B;
        LinkedButtonTextSell.text = C;
        LinkedTextCost.text = B + System.Environment.NewLine + C;
    }
}
