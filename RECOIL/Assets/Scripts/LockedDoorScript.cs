using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public PlayerMovement playerMovement;
    public Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovement = UnityEngine.Object.FindFirstObjectByType<PlayerMovement>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            spriteRenderer.enabled = true;
            collider.enabled = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && playerMovement.playerkeys > 0)
        {
            playerMovement.playerkeys = playerMovement.playerkeys - 1;
            spriteRenderer.enabled = false;
            collider.enabled = false;
        }
    }
}
