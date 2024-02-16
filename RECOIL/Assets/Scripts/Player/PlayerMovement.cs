using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 movement;
    public Rigidbody2D rb;
    public Rigidbody2D shotgunbody;
    public SpriteRenderer shotgunsprites;
    public AudioSource audioSource;
    public AudioClip dieclip;
    public Animator animator;
    [SerializeField] float movespeed = 5f;
    public int playerkeys;
    public bool playeralive = true;



    void Update()
     {
        
        //movement.x = Input.GetAxisRaw("Horizontal");
        // print(movement.x);

         if (playeralive == true)
        {
            Addforce();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
    }

    void Addforce()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector2(0.1f, 0.1f), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector2(-0.1f, 0.1f), ForceMode2D.Impulse);
        }
        rb.AddForce(new Vector2( movement.x * movespeed, 0f), ForceMode2D.Impulse);

   }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("KillPlayer"))
        {
            audioSource.PlayOneShot(dieclip, 1f);
            animator.SetTrigger("PlayerDeath");
            playeralive = false;
            
        }
        if (collision.gameObject.CompareTag("Locked") && playerkeys > 0)
        {
            playerkeys = playerkeys - 1;
            Destroy(collision.gameObject);
            //Destroy(gameObject);
        }
    }


    // IEnumerator RestartScene()
    // {

    // }
    private void FixedUpdate()
    {
       // movement = movement.normalized;
      //  rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
    }
}

