using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeaponItemData : ItemData
{
    [Header("Ranged Weapon Data")]
    public float FireRate;
    public GameObject projectilePrefab;
    public ItemData ProjectileItemData;

    public void Fire (Vector3 spawnPosition, Quaternion spawnRotation, Character.Team team)
    {

    }
}