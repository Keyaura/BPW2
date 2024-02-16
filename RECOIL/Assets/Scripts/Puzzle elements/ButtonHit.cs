using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHit : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite buttonactivated;
    public Sprite buttoninactive;
    public bool playeractivated;
    public bool boxactivated;
    public GameObject target;
    public bool activated;
    public bool stayactivated;
    
    // Start is called before the first frame update


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && playeractivated == true)
        {
            spriteRenderer.sprite = buttonactivated;
            activated = true;
            Destroy(target);
        }
        if (collision.gameObject.CompareTag("Box") && boxactivated == true)
        {
            spriteRenderer.sprite = buttonactivated;
            activated = true;
            Destroy(target);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (stayactivated == false)
        {
            spriteRenderer.sprite = buttoninactive;
            activated = false;

        }
    }
}
