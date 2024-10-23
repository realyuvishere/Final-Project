using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Global Variables Object")]
public class GlobalVariables : ScriptableObject
{
    public bool isWeaponBeingInspected = false;
    public bool isWeaponBeingFired = false;
    public bool isWeaponInExhibit = false;
    public bool areAllWeaponsOnWall = true;



}
