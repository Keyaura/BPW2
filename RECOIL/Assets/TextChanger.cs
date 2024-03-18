using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextChanger : MonoBehaviour
{
    public TMP_Text texttarget;
    public string texttodisplay;
    public string currenttext;
    // Start is called before the first frame update
    private void Start()
    {
        currenttext = texttarget.text;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            texttarget.text = texttodisplay;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            texttarget.text = currenttext;
        }
    }
}
