using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UGCannons : MonoBehaviour
{
    public int initialPrice;

    [SerializeField] private GameManagerConfig gmConfig;
    [SerializeField] private Text priceText;
    [SerializeField] private Text valueText;

    [HideInInspector]
    public int price;

    // Start is called before the first frame update
    void Start()
    {
        price = initialPrice * gmConfig.cannonsLevel;

        if(gmConfig.cannonsLevel < 5)
        {
            priceText.text = " $ " + price;
            valueText.text = " " + gmConfig.cannonsLevel + " > " + (gmConfig.cannonsLevel + 1);
        }
        else
        {
            priceText.text = " MAX";
            valueText.text = " MAX";
        }
        
    }

    public void UpGradeCannons()
    {
        if (gmConfig.cannonsLevel <= 5)
        {
            gmConfig.numberOfCannons++;
            valueText.text = " " + gmConfig.cannonsLevel + " > " + (gmConfig.cannonsLevel + 1);

            price = initialPrice * gmConfig.cannonsLevel;
            priceText.text = " $ " + price;

            if (gmConfig.cannonsLevel >= 5)
            {
                priceText.text = " MAX";
                valueText.text = " MAX";
            }

        }

    }


}
