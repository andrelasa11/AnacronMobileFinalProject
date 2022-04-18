using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialsController : MonoBehaviour
{
    [SerializeField] private GameObject shield;

    private Coroutine shieldCoroutine;

    public void UnlockSpecial (PickupConfig config)
    {
        Debug.LogFormat("SpecialsController: UnlockSpecial pickup type {0}", config.type);

        switch(config.type)
        {
            case PickupType.Shield:
                if(shieldCoroutine != null)
                {
                    StopCoroutine(shieldCoroutine);
                }
                shield.SetActive(true);
                shieldCoroutine = StartCoroutine(DisableAfterSeconds(shield, config.durationInSeconds));
                break;
        }
    }

    private IEnumerator DisableAfterSeconds(GameObject objectToDisable, float time)
    {
        yield return new WaitForSeconds(time);
        objectToDisable.SetActive(false);
    }
}
