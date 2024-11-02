using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Global Variables Object")]
public class GlobalVariables : ScriptableObject
{
    // booleans
    public bool isWeaponBeingInspected = false;
    public bool isWeaponBeingFired = false;
    public bool isWeaponInExhibit = false;
    public bool isExitExhibitMenuDisplayed = false;
    public bool areAllWeaponsOnWall = true;

    // dynamic values
    public float exhibitExitTimeOutStart = 0.0f;

    // threshold values
    public float exhibitExitTimeOutThreshold = 5.0f;
    public float cursorZIndex = 2f;
    public float weaponExhibitZIndex = 4f;
    public float fixedMenuZIndex = 3f;


    // constant tags
    public string SELECTED_WEAPON_TAG = "SelectedWeapon";
    public string DEFAULT_TAG = "Untagged";
    public string EXHIBIT_MENU_TAG = "ExitExhibitMenuContainer";

}
