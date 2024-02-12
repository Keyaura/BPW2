using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 movement;
    public Rigidbody2D rb;
    [SerializeField] float movespeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnCollisionEnter2D()
    {
    }

    //Update is called once per frame
    void Update()
     {
        movement.x = Input.GetAxisRaw("Horizontal");
          print(movement.x);
        Addforce();
    }

    void Addforce()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(new Vector2(1, 1f), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(new Vector2(-1, 1f), ForceMode2D.Impulse);
        }
        rb.AddForce(new Vector2( movement.x * movespeed, 0f), ForceMode2D.Impulse);

   }

    private void FixedUpdate()
    {
       // movement = movement.normalized;
      //  rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
    }
}

