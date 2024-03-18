using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TeleportationScript : MonoBehaviour
{
    public GameObject killbox;
    public GameObject entrypoint;
    public GameObject exitpoint;
    private Collider2D piss;
    public AudioSource audioSource;
    public AudioClip teleportentry;
    public AudioClip teleportexit;
    public AudioClip levelbeaten;
    public ShotgunLaunch shotgunLaunch;
    [SerializeField] bool isexit;
    [SerializeField] private int shotgunshells;
    private void Awake()
    {
        entrypoint = this.gameObject;
        shotgunLaunch = UnityEngine.Object.FindFirstObjectByType<ShotgunLaunch>();
        killbox = GameObject.FindGameObjectWithTag("Killbox");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isexit)
        {
            Collider2D piss = exitpoint.GetComponent<Collider2D>();
            piss.enabled = false;
            audioSource.PlayOneShot(teleportentry);
            StartCoroutine(portalsound());
        }
       
        if (isexit == true) 
        {
            killbox.transform.position = exitpoint.gameObject.transform.position - new Vector3(100, 0, 0);
            collision.attachedRigidbody.velocity = Vector2.zero;
            shotgunLaunch.playerammo = shotgunshells;
            shotgunLaunch.startingammo = shotgunshells;

            audioSource.PlayOneShot(levelbeaten);
        }
        collision.transform.position = exitpoint.gameObject.transform.position;
        StartCoroutine(portalcooldown());
    }
    IEnumerator portalcooldown()
    {
        
        yield return new WaitForSeconds(0.5f);
        if (!isexit) 
        {
            Collider2D piss = exitpoint.GetComponent<Collider2D>();
            piss.enabled = true;
        }
        
    }
    IEnumerator portalsound() 
    {
        yield return new WaitForSeconds(0.1f);
        audioSource.PlayOneShot(teleportexit);
    }
}
