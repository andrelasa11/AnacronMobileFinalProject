using UnityEngine;
using UnityEngine.UI;

public class UGFireRate : MonoBehaviour
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
        price = initialPrice * gmConfig.fireRateLevel;

        if (gmConfig.fireRateLevel < 5)
        {
            priceText.text = " $ " + price;
            valueText.text = " " + gmConfig.fireRateLevel + " > " + (gmConfig.fireRateLevel + 1);
        }
        else
        {
            priceText.text = " MAX";
            valueText.text = " MAX";
        }
        
    }
   
    public void UpGradeFireRate()
    {
        if (gmConfig.fireRateLevel <= 5)
        {
            gmConfig.fireRate -= 0.1f;
            valueText.text = " " + gmConfig.fireRateLevel + " > " + (gmConfig.fireRateLevel + 1);

            price = initialPrice * gmConfig.fireRateLevel;
            priceText.text = " $ " + price;

            if (gmConfig.fireRateLevel >= 5)
            {
                priceText.text = " MAX";
                valueText.text = " MAX";
            }

        }

    }
}
