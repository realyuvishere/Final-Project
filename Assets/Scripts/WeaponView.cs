using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponView : MonoBehaviour
{

    public GlobalVariables vars;

    private bool isSelected = false;    
    private bool isExhibit = false;
    private bool isShooting = false;
    private bool isUnselectable = false;
    private bool isCameraPositionUpdatedToInspectionTable = false;

    private Vector3 _selectedPositionParent = new Vector3(4.5f, .6f, -3.2f);

    private Renderer _myRenderer;
    private Vector3 _initialParentPosition;
    private Vector3 _initialPosition;
    private Quaternion _initialParentRotation;
    private Vector3 _initialCamPosition;
    private Quaternion _initialCamRotation;

    public Transform cam;

    private float exhibitRotationThreshold = 5f;


    void Start()
    {
        _initialParentPosition = transform.parent.localPosition;
        _initialParentRotation = transform.parent.localRotation;
        _initialCamPosition = cam.parent.localPosition;
        _initialCamRotation = cam.parent.localRotation;
        _myRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // isUnselectable = transform.parent.
        if (isSelected)
        {
            _selectWeapon();
        }



        if (isExhibit)
        {
            _exhibit();
        }
    }

    private void _exhibit()
    {
        cam.parent.position = new Vector3(0, 2, 100);
        gameObject.GetComponent<Collider>().enabled = false;
        Vector3 targetPos = cam.position + cam.forward * 4;
        transform.parent.position = targetPos;
        Vector3 camAngles = cam.rotation.eulerAngles;
        transform.parent.LookAt(cam.position);
        transform.parent.Rotate(
            camAngles.z*exhibitRotationThreshold, 
            camAngles.y*exhibitRotationThreshold, 
            camAngles.x*exhibitRotationThreshold
        );
    }

    public void OnTiltInteract()
    {
        if (!isSelected && !isExhibit && !isShooting && !vars.isWeaponBeingInspected && !vars.isWeaponInExhibit && !vars.isWeaponBeingFired)
        {
            vars.areAllWeaponsOnWall = false;
            vars.isWeaponBeingInspected = true;
            isSelected = true;
        }

    }

    public void OnPointerEnter()
    {
        if (!isSelected || isUnselectable)
        {
            transform.localPosition = new Vector3(0, 0.1f, 0);
        }
    }

    public void OnPointerExit()
    {
        if (!isSelected || isUnselectable)
        {
            transform.localPosition = _initialPosition;
        }
    }

    public void ExhibitWeapon()
    {
        isExhibit = true;
        isSelected = false;
        isShooting = false;
        vars.isWeaponInExhibit = true;
        vars.isWeaponBeingInspected = false;
        vars.isWeaponBeingFired = false;
    }

    public void GetOutOfExhibit()
    {
        isExhibit = false;
    }

    public void PutWeaponBack()
    {
        isSelected = false;
        vars.isWeaponBeingInspected = false;
        _unselectWeapon();
    }

    private void _selectWeapon()
    {
        tag = vars.SELECTED_WEAPON_TAG;
        transform.parent.localPosition = _selectedPositionParent;
        transform.parent.localRotation = Quaternion.Euler(0, 90, 0);

        cam.parent.localPosition = new Vector3(2.5f, 2f, 1.5f);

    }

    private void _unselectWeapon()
    {
        tag = vars.DEFAULT_TAG;
        transform.parent.localPosition = _initialParentPosition;
        transform.parent.localRotation = _initialParentRotation;

        cam.parent.localPosition = _initialCamPosition;
    }

}
