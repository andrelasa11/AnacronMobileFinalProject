using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroller : MonoBehaviour
{
    [Header("Configuration")]
    public float scrollSpeed;

    [Header("Dependencies")]
    [SerializeField] private MeshRenderer meshRenderer;

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0, Time.time * scrollSpeed);
        meshRenderer.material.mainTextureOffset = offset;
    }
}
