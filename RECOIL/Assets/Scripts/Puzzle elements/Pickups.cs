using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public ShotgunLaunch _playerShotgunScript;
    public PlayerMovement _playerMovementScript;
    public Transform transform;
    public int ammogiven = 0;
    public int keysgiven = 0;
    public float height = 0.25f;
    public float speed = 5f;
    // Start is called before the first frame update
    private void Awake()
    {
        _playerShotgunScript = UnityEngine.Object.FindFirstObjectByType<ShotgunLaunch>();
        _playerMovementScript = UnityEngine.Object.FindFirstObjectByType<PlayerMovement>();
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerShotgunScript.playerammo += ammogiven;
            _playerMovementScript.playerkeys += keysgiven;
            Destroy(gameObject);
        }
    }
}
