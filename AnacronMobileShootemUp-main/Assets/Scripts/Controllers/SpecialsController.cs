using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialsController : MonoBehaviour
{
    [SerializeField] private GameObject shield;
    [SerializeField] private HealthController shieldHealth;
    [SerializeField] private HealthController playerHealth;
    [SerializeField] private PlayerController playerController;

    public void UnlockSpecial (PickupConfig config)
    {
        Debug.LogFormat("SpecialsController: UnlockSpecial pickup type {0}", config.type);

        switch(config.type)
        {
            case PickupType.Shield:
                shieldHealth.healthPoints = shieldHealth.maxHealth;
                shield.SetActive(true);
                break;

            case PickupType.Heal:
                if(playerHealth != null)
                {
                    playerHealth.Healing(4f);
                } break;

            case PickupType.Laser:
                if(playerController != null)
                {
                    playerController.IncreaseLaserPoints(1);
                } break;

        }
    }

    /*private IEnumerator DisableAfterSeconds(GameObject objectToDisable, float time)
    {
        yield return new WaitForSeconds(time);
        objectToDisable.SetActive(false);
    }*/
}
