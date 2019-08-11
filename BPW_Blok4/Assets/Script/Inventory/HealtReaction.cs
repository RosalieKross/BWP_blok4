using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtReaction : Powerup
{
    public FloatValue playerHealth;
    public Signal healthSignal;

    public void Use(int amountToIncrease)
    {
        playerHealth.RunTimeValue += amountToIncrease;
        healthSignal.Raise();
        SoundManager.PlayeSound("DrikPotion");
    }
}
