using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public PickupConfig config;

    public void OnPickedUp()
    {
        GameController.Instance.OnPickupPickedUp(this);
    }
    
}
