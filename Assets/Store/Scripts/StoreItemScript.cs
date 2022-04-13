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
        LinkedTextCost.text = "Cost: " + Cost.ToString() + "$";
    }

    public void OnPress()
    {
        if (NowCanBuy) {
            Debug.Log(NameTitle);
        }
    }



}
