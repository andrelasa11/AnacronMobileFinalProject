using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tinter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public Color tintColor;
    [SerializeField] private float cadence;

    //private
    private Color originalColor;

    private void Awake()
    {
        originalColor = spriteRenderer.color;
    }

    public void DoTint()
    {
        spriteRenderer.color = tintColor;
        Invoke(nameof(TintBackToOriginal), cadence);
    }   

    public void TintBackToOriginal()
    {
        spriteRenderer.color = originalColor;
    }
}
