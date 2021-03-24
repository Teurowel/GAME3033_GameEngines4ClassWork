using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Items/Consumable", order = 2)]
public class ConsumableScriptable : ItemScriptables
{
    public int Effect = 0;

    public override void UseItem(PlayerController controller)
    {
        //If we are full health, return
        if(controller.Health.Health >= controller.Health.MaxHealth)
        {
            return;
        }

        //Heal player
        controller.Health.HealPlayer(Effect);

        //Deacrease amount
        SetAmount(Amount - 1);
        if(Amount <= 0)
        {
            DeleteItem(controller);
        }
    }
}
