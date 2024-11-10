using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPointScript : MonoBehaviour
{
    public GlobalVariables vars;
    public int points = 10;

    void BulletHit()
    {
        vars.AddPoints(points);
    }
}
