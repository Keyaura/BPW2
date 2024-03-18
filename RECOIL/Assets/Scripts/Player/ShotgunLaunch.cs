using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunLaunch : MonoBehaviour
{
    [SerializeField] AudioClip FireClip;
    [SerializeField] AudioClip NearEmptyClip;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip EmptyClip;
    [SerializeField] AudioClip LowAmmoWarning;
    public GameObject player;
    public Rigidbody2D playerbody;
    public Transform playertf;
    public Transform launchpoint;
    public PlayerMovement _playerMovementScript;
    public SpriteRenderer spriteRenderer;
    public GameObject shotguncorpse;
    public SpriteRenderer shotguncorpserenderer;
    public Rigidbody2D shotguncorpserb;
    public int startingammo;
    public int playerammo;
    public bool playerdied;
    public bool playershot;
    public GameObject lmao;
    [SerializeField]  float thrust = 1f;
    [SerializeField] float thrustmodifier = 1.3f;
    Vector2 knockback;

    private void Awake()
    {
        player = this.gameObject;
        _playerMovementScript = UnityEngine.Object.FindFirstObjectByType<PlayerMovement>();
        playerammo = startingammo;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            PlayerShoot();
        }
        if (_playerMovementScript.playeralive == false && playerdied == false)
        {
            spriteRenderer.enabled = false;
            lmao = Instantiate (shotguncorpse, launchpoint.position, launchpoint.rotation);
            shotguncorpserb.AddForce(-knockback, ForceMode2D.Impulse);
            if (new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height).x <= 0.5)
            {
                shotguncorpserenderer.flipY = false;
            }
            else if (new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height).x <= 0.5)
            {
                shotguncorpserenderer.flipY = true;
            }
            playerdied = true;
                //this.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            spriteRenderer.enabled = true;
            playerdied = false;
            Destroy(lmao);
            playerammo = startingammo;
        }
            Vector2 direction = launchpoint.position - playertf.position;
        knockback = direction *( thrust * thrustmodifier);
        // print(direction);
       // print(knockback);
    }
    IEnumerator LowAmmoWarningSFX()
    {
        yield return new WaitForSeconds(0.5f);
        audioSource.PlayOneShot(LowAmmoWarning);
    }
    void PlayerShoot()
    {
        if (_playerMovementScript.playeralive == true)
        {
            if (playerammo > 0 && playershot == false)
            {
                audioSource.PlayOneShot(FireClip);
                //playerbody.AddForce(knockback, ForceMode2D.Impulse);
                playerbody.AddForce(-knockback, ForceMode2D.Impulse);
                //print("player shoot");
                playerammo  -= 1;
                if (playerammo <= 0)
                {
                    audioSource.PlayOneShot(NearEmptyClip);
                    StartCoroutine(LowAmmoWarningSFX());
                }
                playershot = true;
            }
            else
            {
                audioSource.PlayOneShot(EmptyClip);
            }
        }
    }

}
