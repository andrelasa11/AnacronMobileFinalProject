using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Dice
{
    public static bool IsChanceSuccess(float chance)
    {
        if (chance == 0)
        {
            return false;
        }

        var randomValue = Random.Range(0, 1f);
        return (chance >= randomValue);
    }
}
