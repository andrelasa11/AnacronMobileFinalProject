using UnityEngine;
using UnityEngine.UI;

public class UGSpeed : MonoBehaviour
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
        price = initialPrice * gmConfig.speedLevel;

        if (gmConfig.speedLevel < 5)
        {
            priceText.text = " $ " + price;
            valueText.text = " " + gmConfig.speedLevel + " > " + (gmConfig.speedLevel + 1);
        }
        else
        {
            priceText.text = " MAX";
            valueText.text = " MAX";
        }
    }

    public void UpGradeSpeed()
    {
        if (gmConfig.speedLevel <= 5)
        {
            gmConfig.speed++;
            valueText.text = " " + gmConfig.speedLevel + " > " + (gmConfig.speedLevel + 1);

            price = initialPrice * gmConfig.speedLevel;
            priceText.text = " $ " + price;

            if (gmConfig.speedLevel >= 5)
            {
                priceText.text = " MAX";
                valueText.text = " MAX";
            }

        }

    }
}
