using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BaseWeapon 
{
    int GetDamage();
    string GetDamageType();
    float GetAttackRate();
    //enum WeaponType GetWeaponType();
}
