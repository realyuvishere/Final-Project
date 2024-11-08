using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitExhibitDialogParent : MonoBehaviour
{
    public GlobalVariables vars;
    private bool vibrated = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (vars.isExitExhibitMenuDisplayed)
        {

            transform.GetChild(0).gameObject.SetActive(true);

            if (!vibrated)
            {
                Handheld.Vibrate();
                vibrated = true;
            }

        } else {
            transform.GetChild(0).gameObject.SetActive(false);
            vibrated = false;
        }
    }
}
