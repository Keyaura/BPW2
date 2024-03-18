using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHit : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite buttonactivated;
    public Sprite buttoninactive;
    public Sprite buttonpressed;
    public bool playeractivated;
    public bool boxactivated;
    public GameObject target;
    public bool activated;
    public bool stayactivated;
    public SpriteRenderer targetsprite;
    public Collider2D targetcollider;

    // Start is called before the first frame update
    private void Awake()
    {
        targetsprite = target.GetComponent<SpriteRenderer>();
        targetcollider = target.GetComponent<Collider2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            targetsprite.enabled = true;
            targetcollider.enabled = true;
            spriteRenderer.sprite = buttoninactive;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && playeractivated == true)
        {
            spriteRenderer.sprite = buttonpressed;
            activated = true;
            targetsprite.enabled = false;
            targetcollider.enabled = false;
        }
        if (collision.gameObject.CompareTag("Box") && boxactivated == true)
        {
            spriteRenderer.sprite = buttonpressed;
            activated = true;
            targetsprite.enabled = false;
            targetcollider.enabled = false;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (stayactivated == false)
        {
            spriteRenderer.sprite = buttoninactive;
            activated = false;
            targetsprite.enabled = true;
            targetcollider.enabled = true;

        }
        else
        {
            spriteRenderer.sprite = buttonactivated;
        }
    }
}
