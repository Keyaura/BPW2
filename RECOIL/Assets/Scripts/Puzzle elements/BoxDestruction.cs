using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestruction : MonoBehaviour
{
    public Transform transform;
    public AudioSource audioSource;
    public AudioClip breakclip;
    public float destructionthreshold = 10f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print(collision.relativeVelocity.magnitude);
            
            if (collision.relativeVelocity.magnitude > destructionthreshold)
            {
                AudioSource.PlayClipAtPoint(breakclip, transform.position);
                Destroy(gameObject);
            }
        }
    }
}
