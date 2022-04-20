using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldController : MonoBehaviour
{
    [SerializeField] private Text goldValueText;

    private void Start()
    {
        UpdateGoldValueText(GameController.Instance.PlayerGold);
        GameController.Instance.OnGoldChanged += OnGoldChanged;
    }

    private void OnGoldChanged(int updatedGold)
    {
        UpdateGoldValueText(updatedGold);
    }

    public void UpdateGoldValueText(int newGold)
    {
        goldValueText.text = newGold.ToString();
    }

    private void OnDestroy()
    {
        if(GameController.Instance != null)
        {
            GameController.Instance.OnGoldChanged -= OnGoldChanged;
        }
    }
}
