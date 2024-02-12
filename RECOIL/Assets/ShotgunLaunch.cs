using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] AudioClip ShotgunClip;
    [SerializeField] AudioSource audioSource;
    public Rigidbody2D playerbody;
    public Transform playertf;
    public Transform transform;
    public Transform launchpoint;
    [SerializeField]  float thrust = 454554f;
    Vector2 knockback;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PlayerShoot();
        }
        // Vector2 rotationshit = transform.rotation;
        print(transform.rotation.eulerAngles.z);
       // launchcalculation = (,thrust);

        //transform.rotation.eulerAngles
        Vector2 direction = launchpoint.position - playertf.position;
        knockback = direction * thrust;
        // print(direction);
        print(knockback);
    }

    void PlayerShoot()
    {
        audioSource.PlayOneShot(ShotgunClip);
        //playerbody.AddForce(knockback, ForceMode2D.Impulse);
        playerbody.AddForce(-knockback, ForceMode2D.Impulse);
        //print("player shoot");
    }
}
