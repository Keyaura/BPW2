using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedInstanciator : MonoBehaviour
{
    public GameObject itemtospawn;
    public Transform itemspawnlocation;
    public bool active;
    public GameObject tempitem;

    private void Start()
    {
        active = false;
        //itemspawnlocation = GetComponentInChildren<Transform>();
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            Destroy(tempitem);
            active = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!active && collision.gameObject.CompareTag("Player"))
        {
            tempitem = Instantiate(itemtospawn, itemspawnlocation);
            active = true;
        }
    }
}
