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

    private bool NowCanBuy = true;
    private bool NowCanSell = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
