using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestruction : MonoBehaviour
{
    public GameObject box;
    public Transform transform;
    public AudioSource audioSource;
    public AudioClip breakclip;
    public Collider2D collider;
    public SpriteRenderer spriteRenderer;
    public float destructionthreshold = 10f;
    private void Awake()
    {
        box = this.gameObject;
        collider = this.GetComponent<Collider2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.relativeVelocity.magnitude > destructionthreshold)
            {
                audioSource.PlayOneShot(breakclip);
                spriteRenderer.enabled = false;
                collider.enabled = false;
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            spriteRenderer.enabled = true;
            collider.enabled=true;
        }
    }
}
