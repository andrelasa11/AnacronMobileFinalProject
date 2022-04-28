using UnityEngine;
using UnityEngine.UI;

public class UGLaser : MonoBehaviour
{
    public int initialPrice;
    public int pointsToIncrease;

    [SerializeField] private GameManagerConfig gmConfig;
    [SerializeField] private Text priceText;
    [SerializeField] private Text valueText;

    [HideInInspector]
    public int price;
    // Start is called before the first frame update
    void Start()
    {
        price = initialPrice * gmConfig.laserLevel;

        if (gmConfig.laserLevel < 5)
        {
            priceText.text = " $ " + price;
            valueText.text = " " + gmConfig.maxLaserPoints + " > " + (gmConfig.maxLaserPoints + 2);
        }
        else
        {
            priceText.text = " MAX";
            valueText.text = " MAX";
        }
    }

    public void UpGradeLaser()
    {
        if (gmConfig.laserLevel <= 5)
        {
            gmConfig.maxLaserPoints += pointsToIncrease;
            valueText.text = " " + gmConfig.maxLaserPoints + " > " + (gmConfig.maxLaserPoints + 2);

            price = initialPrice * gmConfig.laserLevel;
            priceText.text = " $ " + price;

            if (gmConfig.laserLevel >= 5)
            {
                priceText.text = " MAX";
                valueText.text = " MAX";
            }

        }

    }
}
