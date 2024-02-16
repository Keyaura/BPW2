using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunLaunch : MonoBehaviour
{
    [SerializeField] AudioClip FireClip;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip EmptyClip;
    public Rigidbody2D playerbody;
    public Transform playertf;
    public Transform launchpoint;
    public PlayerMovement _playerMovementScript;
    public SpriteRenderer spriteRenderer;
    public GameObject shotguncorpse;
    public SpriteRenderer shotguncorpserenderer;
    public Rigidbody2D shotguncorpserb;
    public int playerammo;
    [SerializeField]  float thrust = 1f;
    Vector2 knockback;

    private void Awake()
    {
        _playerMovementScript = UnityEngine.Object.FindFirstObjectByType<PlayerMovement>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            PlayerShoot();
        }
        if (_playerMovementScript.playeralive == false)
        {
            spriteRenderer.enabled = false;
            Instantiate (shotguncorpse, launchpoint.position, launchpoint.rotation);
            shotguncorpserb.AddForce(-knockback, ForceMode2D.Impulse);
            if (new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height).x <= 0.5)
            {
                shotguncorpserenderer.flipY = true;
            }
                this.enabled = false;
        }
        Vector2 direction = launchpoint.position - playertf.position;
        knockback = direction * thrust;
        // print(direction);
       // print(knockback);
    }

    void PlayerShoot()
    {
        if (_playerMovementScript.playeralive == true)
        {
            if (playerammo > 0)
            {
                audioSource.PlayOneShot(FireClip);
                //playerbody.AddForce(knockback, ForceMode2D.Impulse);
                playerbody.AddForce(-knockback, ForceMode2D.Impulse);
                //print("player shoot");
                playerammo  -= 1;
            }
            else
            {
                audioSource.PlayOneShot(EmptyClip);
            }
        }
    }
}
