using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotater
{
    GameObject _weapon;
    public WeaponRotater(GameObject weapon)
    {
        _weapon = weapon;
    }
    public void RotateWeapon(float angleValue)
    {
        angleValue = Mathf.Clamp(angleValue, -60, 60);
        _weapon.transform.rotation = Quaternion.Euler(0, 0, angleValue);
    }
}