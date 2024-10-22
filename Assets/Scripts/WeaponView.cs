using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponView : MonoBehaviour
{

    // public bool ShitMe;

    private bool isSelected = false;    
    private bool isExhibit = false;
    private bool isShooting = false;
    private bool isUnselectable = false;

    private Vector3 _selectedPositionParent = new Vector3(0f, -0.66f, -3f);

    private Renderer _myRenderer;
    private Vector3 _startingParentPosition;
    private Vector3 _startingPosition;


    void Start()
    {
        _startingParentPosition = transform.parent.localPosition;
        _startingPosition = transform.localPosition;
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
    }

    public void OnTiltInteract()
    {
        if (!isSelected && !isExhibit && !isShooting) isSelected = true;
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

    

}
