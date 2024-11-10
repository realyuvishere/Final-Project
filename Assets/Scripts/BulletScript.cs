using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public AmmoScriptable Ammo {get; set;}
    public AudioSource bulletSoundSource;
    public AudioClip bulletSound;

    void Start()
    {
        bulletSoundSource.PlayOneShot(bulletSound);
        Handheld.Vibrate();
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Ammo.velocity * Time.deltaTime))
        {
            transform.position = hit.point;
            hit.collider.gameObject.SendMessage("BulletHit", SendMessageOptions.DontRequireReceiver);
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject, 1f);
            Destroy(this);
        } else {
            transform.Translate(Vector3.forward * Ammo.velocity * Time.deltaTime);
        }
    }
}
