using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectionButtonScript : MonoBehaviour
{
    public Material defaultMaterial;
    public Material hoverMaterial;
    public GlobalVariables vars;

    public bool isPutBack = false;
    public bool isExhibit = false;
    public bool isShoot = false;

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
        if (vars.isWeaponBeingInspected)
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
        if (isPutBack)
        {
            GameObject.FindWithTag(vars.SELECTED_WEAPON_TAG).SendMessage("PutWeaponBack");
        }

        if (isExhibit)
        {
            GameObject.FindWithTag(vars.SELECTED_WEAPON_TAG).SendMessage("ExhibitWeapon");
        }
    }

    private void SetMaterial(bool isHovered)
    {
        if (hoverMaterial != null && defaultMaterial != null)
        {
            _renderer.material = isHovered ? hoverMaterial : defaultMaterial;
        }
    }
}
