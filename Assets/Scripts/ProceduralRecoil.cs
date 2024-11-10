using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralRecoil : MonoBehaviour
{
    public Transform cam;
    public AmmoScriptable ammo;
    private Vector3 currentRotation, targetRotation, targetPosition, currentPosition, initialPosition;

    // Update is called once per frame
    void Update()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, ammo.returnThreshold * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, ammo.snappiness * Time.fixedDeltaTime);
        cam.localRotation = Quaternion.Euler(currentRotation);
        back();
    }

    public void recoil() {
        targetRotation += new Vector3(-ammo.recoilX, Random.Range(-ammo.recoilY, ammo.recoilY), Random.Range(-ammo.recoilZ, ammo.recoilZ));
        targetPosition += new Vector3(0, 0, -ammo.kickbackZ);
    }

    private void back() {
        targetPosition = Vector3.Lerp(targetPosition, initialPosition, ammo.returnThreshold * Time.deltaTime);
        currentPosition = Vector3.Lerp(currentPosition, targetPosition, ammo.snappiness * Time.fixedDeltaTime);
        transform.localPosition = currentPosition;
    }


}
