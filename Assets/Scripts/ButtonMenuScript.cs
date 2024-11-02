using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMenuScript : MonoBehaviour
{

    public GlobalVariables vars;
    public bool isInspectionMenu = false;
    public bool isShootingRangeMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((vars.isWeaponBeingInspected && isInspectionMenu) || (vars.isWeaponBeingFired && isShootingRangeMenu))
        {
            _updateChildrenActive(true);
        } else
        {
            _updateChildrenActive(false);
        }

    }

    private void _updateChildrenActive(bool b)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(b);
        }
    }
}
