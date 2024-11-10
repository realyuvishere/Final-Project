using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Ammo")]
public class AmmoScriptable : ScriptableObject
{
    public float velocity = 300;
    public float fireRate = 1;
    // public float damage = 10;
    // public float range = 100;
    // public float weight = 1;
    public int maxAmmo = 10;
    public float recoilX = 1f;
    public float recoilY = 1f;
    public float recoilZ = 1f;
    public float kickbackZ = 1f;
    public float snappiness = 1f;
    public float returnThreshold = 1f;

    public Vector3 currentRotation, targetRotation, targetPosition, currentPosition, initialWeaponPosition;

    public void _recoilUpdate(Transform cam, Transform transform)
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnThreshold * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, snappiness * Time.fixedDeltaTime);
        cam.parent.localRotation = Quaternion.Euler(currentRotation);
        back(transform);
    }

    public void recoil() {
        targetRotation += new Vector3(-recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
        // targetPosition += new Vector3(0, 0, -kickbackZ);
    }

    private void back(Transform transform) {
        // targetPosition = Vector3.Lerp(targetPosition, initialWeaponPosition, returnThreshold * Time.deltaTime);
        // currentPosition = Vector3.Lerp(currentPosition, targetPosition, snappiness * Time.fixedDeltaTime);
        // transform.parent.localPosition = currentPosition;
    }
}
