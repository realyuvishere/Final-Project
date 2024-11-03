using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectionButtonScript : MonoBehaviour
{
    public Material defaultMaterial;
    public Material hoverMaterial;
    public GlobalVariables vars;

    public bool isPutBackBtn = false;
    public bool isExhibitBtn = false;
    public bool isShootBtn = false;
    public bool isIgnoreExhibitExitBtn = false;
    public bool isShootingRangeButton = false;
    public bool isSelectionButton = false;
    public bool isFireBtn = false;
    // public bool 
    public bool staysActive = false;

    private Renderer _renderer;
    private Vector3 _startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.parent.localPosition;
        _renderer = GetComponent<Renderer>();
        SetMaterial(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((vars.isWeaponBeingInspected && isSelectionButton) || (vars.isWeaponBeingFired && isShootingRangeButton) || staysActive)
        {
            transform.parent.gameObject.SetActive(true);
        } else
        {
            transform.parent.gameObject.SetActive(false);
        }
    }

    public void OnPointerEnter()
    {
        SetMaterial(true);
    }

    public void OnPointerExit()
    {
        SetMaterial(false);
    }

    public void OnTiltInteract()
    {
        if (isPutBackBtn)
        {
            GameObject.FindWithTag(vars.SELECTED_WEAPON_TAG).SendMessage("PutWeaponBack");
        }

        if (isExhibitBtn)
        {
            GameObject.FindWithTag(vars.SELECTED_WEAPON_TAG).SendMessage("ExhibitWeapon");
        }

        if (isIgnoreExhibitExitBtn) {
            vars.exhibitExitTimeOutStart = Time.time;
            vars.isExitExhibitMenuDisplayed = false;
        }

        if (isShootBtn)
        {
            GameObject.FindWithTag(vars.SELECTED_WEAPON_TAG).SendMessage("ShootingRange");
        }

        if (isFireBtn)
        {
            GameObject.FindWithTag(vars.SELECTED_WEAPON_TAG).SendMessage("FireWeapon");
        }
    }

    public void OnPointerClick() {
        OnTiltInteract();
    }

    private void SetMaterial(bool isHovered)
    {
        if (hoverMaterial != null && defaultMaterial != null)
        {
            _renderer.material = isHovered ? hoverMaterial : defaultMaterial;
        }
    }
}
