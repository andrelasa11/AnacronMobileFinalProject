using UnityEngine;
using UnityEngine.UI;

public class UGShootDamage : MonoBehaviour
{
    public int initialPrice;

    [SerializeField] private GameManagerConfig gmConfig;
    [SerializeField] private Text priceText;
    [SerializeField] private Text valueText;

    [HideInInspector]
    public int price;
  
    private void Start()
    {
        price = initialPrice * gmConfig.shootDamageLevel;

        if (gmConfig.shootDamageLevel < 5)
        {
            priceText.text = " $ " + price;
            valueText.text = " " + gmConfig.playerBulletDamage + " > " + (gmConfig.playerBulletDamage + 0.5f);
        }
        else
        {
            priceText.text = " MAX";
            valueText.text = " MAX";
        }
        
    }

    public void UpGradeShootDamage()
    {
        if (gmConfig.shootDamageLevel <= 5)
        {
            gmConfig.playerBulletDamage += 0.5f;
            valueText.text = " " + gmConfig.playerBulletDamage + " > " + (gmConfig.playerBulletDamage + 0.5f);

            price = initialPrice * gmConfig.shootDamageLevel;
            priceText.text = " $ " + price;

            if (gmConfig.shootDamageLevel >= 5)
            {
                priceText.text = " MAX";
                valueText.text = " MAX";
            }

        }
        
    }

}
