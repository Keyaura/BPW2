using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillboxRelocator : MonoBehaviour
{
    public GameObject killbox;
    public GameObject relocator;
    // Start is called before the first frame update
    void Start()
    {
        killbox = GameObject.FindGameObjectWithTag("Killbox");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            killbox.transform.position = relocator.gameObject.transform.position - new Vector3(100, 0, 0);
        }
    }
}
