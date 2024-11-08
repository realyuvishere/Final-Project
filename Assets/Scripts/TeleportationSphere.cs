using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationSphere : MonoBehaviour
{
    public Transform player;

    public void OnTiltInteract() {
        _teleport();
    }

    public void OnPointerClick() {
        _teleport();
    }

    public void OnGazeInteract() {
        _teleport();
    }
    private void _teleport() {
        player.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
    }
}
