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

    [Header("Link fields")]
    public Image LinkedImage;
    public Text LinkedTextItemName;
    public Text LinkedTextCost;
    public GameObject PanelByOrSell;

    public bool NowCanBuy = true;
    public bool NowCanSell = true;
    private Image Image;

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

    }

    void SetItemAtrributes()
    {
        LinkedImage.sprite = Icon;
        LinkedTextItemName.text = NameTitle;
        LinkedTextCost.text = CostIntToString(Cost);
    }

    string CostIntToString(int cost)
    {
        return "Cost: " + cost.ToString() + "$";
    }

    int CalculateSellCost(int cost)
    {
        return cost / 2;
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
            storeBuyOrSellScript.SellCost = CalculateSellCost(Cost);
            storeBuyOrSellScript.NowCanBuy = NowCanBuy;
            storeBuyOrSellScript.NowCanSell = NowCanSell;
        }
    }



}
