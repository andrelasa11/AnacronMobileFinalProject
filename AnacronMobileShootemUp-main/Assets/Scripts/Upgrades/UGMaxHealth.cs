using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UGMaxHealth : MonoBehaviour
{
    public int initialPrice;
    public float healthToIncrease;

    [SerializeField] private GameManagerConfig gmConfig;
    [SerializeField] private Text priceText;
    [SerializeField] private Text valueText;

    [HideInInspector]
    public int price;

    private void Start()
    {
        price = initialPrice * gmConfig.maxHealthLevel;

        if (gmConfig.maxHealthLevel < 5)
        {
            priceText.text = " $ " + price;
            valueText.text = " " + gmConfig.maxHealthLevel + " > " + (gmConfig.maxHealthLevel + 1);
        }
        else
        {
            priceText.text = " MAX";
            valueText.text = " MAX";
        }
    }

    public void UpGradeMaxHealth()
    {
        if (gmConfig.maxHealthLevel <= 5)
        {
            gmConfig.maxHealth += healthToIncrease;
            valueText.text = " " + gmConfig.maxHealthLevel + " > " + (gmConfig.maxHealthLevel + 1);

            price = initialPrice * gmConfig.maxHealthLevel;
            priceText.text = " $ " + price;

            if (gmConfig.maxHealthLevel >= 5)
            {
                priceText.text = " MAX";
                valueText.text = " MAX";
            }

        }

    }
}
