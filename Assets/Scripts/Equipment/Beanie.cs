using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beanie : EquipmentItem
{
    public float speedMultiplier = 1.5f;

    public override void OnEquip(GameObject character)
    {
        PlayerController player = character.GetComponent<PlayerController>();
        player.moveSpeed *= speedMultiplier;
    }

    public override void OnUnequip(GameObject character)
    {
        PlayerController player = character.GetComponent<PlayerController>();
        player.moveSpeed /= speedMultiplier;
    }

}
