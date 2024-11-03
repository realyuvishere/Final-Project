using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitExhibitDialogContainer : MonoBehaviour
{
    public Transform cam;
    public GlobalVariables vars;
    // Start is called before the first frame update
    void Start()
    {

        transform.position = cam.position + cam.forward * vars.weaponExhibitZIndex;
        transform.LookAt(cam.position);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
