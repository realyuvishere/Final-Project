using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponView : MonoBehaviour
{

    public GlobalVariables vars;
    public Transform cam;
    public Transform muzzle;
    public GameObject bulletPrefab;
    public AmmoScriptable ammo;
    public float shootingXOffset = 0f;
    public float shootingYOffset = -0.3f;
    public float shootingZOffset = 0f;

    public AudioSource weaponSoundSource;
    public AudioClip weaponCockingSound;
    public AudioClip weaponFireSound;

    private bool isSelected = false;    
    private bool isExhibit = false;
    public bool isShooting = false;
    public bool isFiring = false;
    private bool isUnselectable = false;

    private Vector3 _selectedPositionParent = new Vector3(4.5f, .6f, -3.2f);

    private Renderer _myRenderer;
    private Vector3 _initialParentPosition;
    private Vector3 _initialPosition;
    private Quaternion _initialParentRotation;
    private Vector3 _initialCamPosition;
    private Quaternion _initialCamRotation;
    private float nextFire = 0f;
    public int currentAmmo = 0;

    
    private float exhibitRotationThreshold = 5f;


    void Start()
    {
        _initialParentPosition = transform.parent.localPosition;
        _initialParentRotation = transform.parent.localRotation;
        _initialCamPosition = cam.parent.localPosition;
        _initialCamRotation = cam.parent.localRotation;
        _myRenderer = GetComponent<Renderer>();
        currentAmmo = ammo.maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        // isUnselectable = transform.parent.

        if (isSelected || isExhibit || isShooting || vars.isWeaponBeingInspected || vars.isWeaponInExhibit || vars.isWeaponBeingFired)
        {
            gameObject.GetComponent<Collider>().enabled = false;
        } else
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
        if (isSelected)
        {
            _selectWeapon();
        }



        if (isExhibit && vars.isWeaponInExhibit && !vars.isExitExhibitMenuDisplayed)
        {
            _exhibit();
        }

        if (isShooting && vars.isWeaponBeingFired)
        {
            _shootingRange();

            if (isFiring)
            {
                _firing();
            }
        }
    }

    public void OnGazeInteract()
    {
        OnTiltInteract();
    }

    public void OnPointerClick() {
        OnTiltInteract();
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

    public void ShootingRange()
    {
        isShooting = true;
        isSelected = false;
        isExhibit = false;
        vars.isWeaponBeingFired = true;
        vars.isWeaponBeingInspected = false;
        vars.isWeaponInExhibit = false;
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

    public void PutWeaponBack()
    {
        isSelected = false;
        isExhibit = false;
        isShooting = false;
        vars.isWeaponBeingInspected = false;
        vars.isWeaponInExhibit = false;
        vars.isWeaponBeingFired = false;
        vars.areAllWeaponsOnWall = true;
        vars.isExitExhibitMenuDisplayed = false;
        vars.exhibitExitTimeOutStart = 0f;
        
        _unselectWeapon();
    }

    public void FireWeapon()
    {
        weaponSoundSource.PlayOneShot(weaponCockingSound);
        // Debug.Log("Cocking weapon" + Time.time);
        Invoke("_switchFiringState", 2f);
    }

    private void _switchFiringState() {
        isFiring = !isFiring;
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

    private void _exhibit()
    {
        cam.parent.position = new Vector3(0, 2, 100);
        Vector3 targetPos = cam.position + cam.forward * vars.weaponExhibitZIndex;
        transform.parent.position = targetPos;
        Vector3 camAngles = cam.rotation.eulerAngles;
        transform.parent.LookAt(cam.position);
        transform.parent.Rotate(
            camAngles.z*exhibitRotationThreshold, 
            camAngles.y*exhibitRotationThreshold, 
            camAngles.x*exhibitRotationThreshold
        );
    }

    private void _shootingRange() {

        // cam.parent.position = new Vector3(0, 2, 0);

        Vector3 camPos = cam.position;
        Vector3 camFor = cam.forward;
        Vector3 targetPos = camPos + camFor * 2;
        transform.parent.position = targetPos;
        transform.parent.LookAt(cam.position);
        transform.parent.Rotate(0, -90, 0);
        transform.localPosition = new Vector3(shootingXOffset, shootingYOffset, shootingZOffset);
    }

    private void _refillAmmo() {
        currentAmmo = ammo.maxAmmo;
    }

    private void _firing() {
        if (currentAmmo == 0)
        {
            Debug.Log("Out of ammo");
            isFiring = false;
            Invoke("_refillAmmo", 2f);
        }

        if (Time.time >= nextFire) 
        {
            var projectile = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
            var bScript = projectile.GetComponent<BulletScript>();
            bScript.Ammo = ammo;
            bScript.bulletSoundSource = weaponSoundSource;
            bScript.bulletSound = weaponFireSound;
            currentAmmo--;
            nextFire = Time.time + ammo.fireRate;
        }
    }


}
