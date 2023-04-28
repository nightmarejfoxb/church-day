using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equip : MonoBehaviour
{
    [SerializeField] protected FoodItemData fooditem;
    [SerializeField] protected ItemData item;
    [SerializeField] protected RangedEquipItem RangedItem;
    [SerializeField] protected MeleeEquipItem MeleeItem;

   public virtual void OnUse()
   {

   }
}
