using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunFollowPlayer : MonoBehaviour
{
    public float movespeed = 5f;

    Vector2 mousePos;
    Vector2 movement;
    public SpriteRenderer weapon;
    public Camera cam;

    public Transform tf;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - (Vector2)tf.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        tf.rotation = Quaternion.Euler(0, 0, angle);
        if (new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height).x >= 0.5)
        {

            weapon.flipY = false;

        }
        else if (new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height).x <= 0.5)
        {
            weapon.flipY = true;


        }
    }
}
