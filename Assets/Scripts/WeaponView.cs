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

    private Vector3 _selectedPositionParent = new Vector3(0f, -0.55f, -3f);

    private Renderer _myRenderer;
    private Vector3 _startingParentPosition;
    private Vector3 _startingPosition;
    private Quaternion _startingRotation;
    private Quaternion _selectedRotation = Quaternion.Euler(0, 0, 0);

    public Transform cam;

    private float exhibitRotationThreshold = 10f;


    void Start()
    {
        _startingParentPosition = transform.parent.localPosition;
        _startingPosition = transform.localPosition;
        _startingRotation = transform.localRotation;
        _myRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // isUnselectable = transform.parent.
        if (isSelected)
        {
            transform.parent.localPosition = _selectedPositionParent;
        }



        if (isExhibit)
        {
            Exhibit();
        }
    }

    private void Exhibit()
    {
        cam.position = new Vector3(0, 2, 100);
        gameObject.GetComponent<Collider>().enabled = false;
        Vector3 targetPos = cam.position + cam.forward * 4;
        transform.parent.position = targetPos;
        Vector3 camAngles = cam.rotation.eulerAngles;
        transform.parent.LookAt(cam.position);
        transform.parent.Rotate(camAngles.z*exhibitRotationThreshold, camAngles.y*exhibitRotationThreshold, camAngles.x*exhibitRotationThreshold);
    }

    public void OnTiltInteract()
    {
        if (!isSelected && !isExhibit && !isShooting)
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
            transform.localPosition = _startingPosition;
        }
    }

    public void TakeToExhibit()
    {
        isExhibit = true;
    }

    public void GetOutOfExhibit()
    {
        isExhibit = false;
    }

    private void PutBack()
    {
        isSelected = false;
        vars.isWeaponBeingInspected = false;
    }

}
