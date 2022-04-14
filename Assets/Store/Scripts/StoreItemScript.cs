using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreItemScript : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Editable fields")]
    public Sprite Icon;
    public string NameTitle;
    public int Cost;
    public Color AvailableForPurchase;
    public Color NotAvailableForPurchase;
    public bool CanBuy = true;
    public bool CanSell = true;
    public int StartAmount;

    [Header("Link fields")]
    public Image LinkedImage;
    public Text LinkedTextItemName;
    public Text LinkedTextCost;
    public Text LinkedTextAmount;
    public GameObject PanelByOrSell;
    public GameObject StorePanel;

    public bool NowCanBuy = true;
    public bool NowCanSell = true;
    public int SiblingIndex;
    private Image Image;
    private int Amount;
    //private StoreMoneyManager moneyManager;

    void Start()
    {
        Image = GetComponent<Image>();
        SetItemAtrributes();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (NowCanBuy) { Image.color = AvailableForPurchase; }
        else { Image.color = NotAvailableForPurchase; }

        Amount = StoreMoneyManager.CountOfItem[SiblingIndex];
        LinkedTextAmount.text = Amount.ToString();

    }

    void SetItemAtrributes()
    {
        LinkedImage.sprite = Icon;
        LinkedTextItemName.text = NameTitle;
        LinkedTextCost.text = CostIntToString(Cost);
        SiblingIndex = transform.GetSiblingIndex();
        StoreMoneyManager.CountOfItem[SiblingIndex] = StartAmount;
    }

    string CostIntToString(int cost)
    {
        return "Cost: " + cost.ToString() + "$";
    }



    public void OnPress()
    {
        StoreBuyOrSellScript storeBuyOrSellScript;
        if (NowCanBuy) {
            PanelByOrSell.SetActive(true);
            storeBuyOrSellScript = PanelByOrSell.GetComponent<StoreBuyOrSellScript>();
            storeBuyOrSellScript.LinkedImage.sprite = Icon;
            //storeBuyOrSellScript.LinkedTextCost.text = CostIntToString(Cost);
            storeBuyOrSellScript.LinkedTextItemName.text = NameTitle;
            storeBuyOrSellScript.BuyCost = Cost;
            storeBuyOrSellScript.SellCost = StoreMoneyManager.CalculateSellCost(Cost);
            //storeBuyOrSellScript.NowCanBuy = NowCanBuy;
            //storeBuyOrSellScript.NowCanSell = NowCanSell;
            storeBuyOrSellScript.SiblingIndex = SiblingIndex;
            if (StoreMoneyManager.CanYouBuy(Cost) > 0) storeBuyOrSellScript.NowCanBuy = true; else storeBuyOrSellScript.NowCanBuy = false;
            if ((StoreMoneyManager.CanYouSell(SiblingIndex) > 0)&&(NowCanSell)) storeBuyOrSellScript.NowCanSell = true; else storeBuyOrSellScript.NowCanSell = false;
            storeBuyOrSellScript.AmountBuy = StoreMoneyManager.CanYouBuy(Cost);
            storeBuyOrSellScript.AmountSell = StoreMoneyManager.CanYouSell(SiblingIndex);
        }
    }



}
