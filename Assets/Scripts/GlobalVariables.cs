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
    public string SELECTED_WEAPON_TAG = "SelectedWeapon";
    public string DEFAULT_TAG = "Untagged";

}
