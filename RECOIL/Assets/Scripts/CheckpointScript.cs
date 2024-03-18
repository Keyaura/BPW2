using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public PlayerMovement _playerMovementScript;
    public Transform checkpointpos;
    public SpriteRenderer spriteRenderer;
    public Sprite checkpointactive;
    public Sprite checkpointinactive;
    public string levelname;
    public GameObject levelinfo;
    public TMP_Text levelinfotext;

    // Start is called before the first frame update
    private void Awake()
    {
        _playerMovementScript = UnityEngine.Object.FindFirstObjectByType<PlayerMovement>();
        checkpointpos = this.GetComponent<Transform>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        levelinfo = GameObject.FindGameObjectWithTag("LevelName");
        levelinfotext = levelinfo.GetComponent<TMP_Text>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _playerMovementScript.checkpoint = checkpointpos;
        spriteRenderer.sprite = checkpointactive;
        levelinfotext.text = levelname;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
