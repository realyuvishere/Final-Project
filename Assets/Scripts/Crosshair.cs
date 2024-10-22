using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Transform cam;
    public Transform staticCrosshair;
    private int rotationThreshold = 2;
    private float deltaRightUpperLimit = 6;
    private float deltaLeftUpperLimit = 84;
    private bool interacted = false;
    private float objectDistanceThreshold = 10;
    void Start()
    {

    }


    void Update()
    {
        Vector3 targetPos = cam.position + cam.forward * 4;
        transform.position = targetPos;
        transform.LookAt(cam.position);
        staticCrosshair.position = targetPos;
        staticCrosshair.LookAt(cam.position);
        staticCrosshair.Rotate(0, 0, 45);

        transform.Rotate(0, 0, -cam.rotation.eulerAngles.z * rotationThreshold);

        float deltaAngle = Quaternion.Angle(transform.rotation, staticCrosshair.rotation);

        if ((deltaAngle < deltaRightUpperLimit || deltaAngle > deltaLeftUpperLimit) && !interacted)
        {
            interacted = true;

            RaycastHit hit;

            if (Physics.Raycast(cam.position, cam.forward, out hit))
            {
                hit.transform.gameObject.SendMessage("OnTiltInteract");

            }
        }

        if (interacted && (deltaAngle > deltaRightUpperLimit && deltaAngle < deltaLeftUpperLimit))
        {
            interacted = false;
        }
    }
}
