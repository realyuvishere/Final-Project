using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Ammo")]
public class AmmoScriptable : ScriptableObject
{
    public float velocity = 1000;
    public float fireRate = 1;
    public float damage = 10;
    public float range = 100;
    public float weight = 1;
    public int maxAmmo = 10;
}
