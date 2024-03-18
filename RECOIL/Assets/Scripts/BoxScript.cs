using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    private Vector3 startinglocation;
    private Quaternion startingrotation;
    private Transform transform;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        startinglocation = transform.position;
        startingrotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            rb.velocity = Vector3.zero;
            transform.position = startinglocation;
            transform.rotation = startingrotation;
        }
    }
}
