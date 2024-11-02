using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Global Variables Object")]
public class GlobalVariables : ScriptableObject
{
    public bool isWeaponBeingInspected = false;
    public bool isWeaponBeingFired = false;
    public bool isWeaponInExhibit = false;
    public bool isExitExhibitMenuDisplayed = false;
    public bool areAllWeaponsOnWall = true;
    public float exhibitExitTimeOutStart = 0.0f;

    public float exhibitExitTimeOutThreshold = 10.0f;

    public string SELECTED_WEAPON_TAG = "SelectedWeapon";
    public string DEFAULT_TAG = "Untagged";
    public string EXHIBIT_MENU_TAG = "ExitExhibitMenuContainer";

}
