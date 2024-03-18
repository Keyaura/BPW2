using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public ShotgunLaunch _playerShotgunScript;
    public PlayerMovement _playerMovementScript;
    public Transform transform;
    public SpriteRenderer spriteRenderer;
    public Collider2D collider;
    public AudioSource audioSource;
    public AudioClip pickupClip;
    public GameObject gameObject;
    public int ammogiven = 0;
    public int keysgiven = 0;
    public float height = 0.25f;
    public float speed = 5f;
    // Start is called before the first frame update
    private void Awake()
    {
        _playerShotgunScript = UnityEngine.Object.FindFirstObjectByType<ShotgunLaunch>();
        _playerMovementScript = UnityEngine.Object.FindFirstObjectByType<PlayerMovement>();
        collider = GetComponent<Collider2D>();
        gameObject = GetComponent<GameObject>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }
    void Update()
    {

        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        if (Input.GetKeyDown(KeyCode.R))
        {
            spriteRenderer.enabled = true;
            collider.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerShotgunScript.playerammo += ammogiven;
            _playerMovementScript.playerkeys += keysgiven;
            spriteRenderer.enabled = false;
            collider.enabled = false;
            audioSource.PlayOneShot(pickupClip);

        }
    }
}
