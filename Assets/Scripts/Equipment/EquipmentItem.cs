using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentItem : MonoBehaviour
{
    public string equipName;
    public string description;

    public virtual void OnEquip(GameObject character)
    {

    }

    public virtual void OnUnequip(GameObject character)
    {

    }
}
