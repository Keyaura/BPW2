using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 movement;
    public GameObject player;
    public Rigidbody2D rb;
    public Rigidbody2D shotgunbody;
    public SpriteRenderer shotgunsprites;
    public AudioSource audioSource;
    public AudioClip dieclip;
    public Animator animator;
    public Transform checkpoint;
    public ShotgunLaunch shotgunLaunch;
    [SerializeField] float movespeed = 5f;
    public float advmovespeed = 1f;
    public int playerkeys;
    public bool playeralive = true;


    private void Awake()
    {
        player = this.gameObject;
        shotgunLaunch = UnityEngine.Object.FindFirstObjectByType<ShotgunLaunch>();
    }
    void FixedUpdate()
     {
        
        //movement.x = Input.GetAxisRaw("Horizontal");
        // print(movement.x);

         if (playeralive == true)
        {
            Addforce();
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //animator.SetTrigger("PlayerDeath");
            //Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

            player.transform.position = checkpoint.position;
            animator.SetBool("PlayerDeath", false);
            animator.SetTrigger("Restart");
            playeralive = true;
            rb.velocity = Vector2.zero;
            player.layer = 3;
            playerkeys = 0;
           
        }
    }
    void Addforce()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector2(advmovespeed, advmovespeed), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector2(-advmovespeed, advmovespeed), ForceMode2D.Impulse);
        }
        rb.AddForce(new Vector2( movement.x * movespeed, 0f), ForceMode2D.Impulse);

   }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("KillPlayer"))
        {
            audioSource.PlayOneShot(dieclip, 1f);
            animator.SetBool("PlayerDeath", true);
            playeralive = false;
            player.layer = 12;
            
        }
        if (collision.gameObject.CompareTag("Locked") && playerkeys > 0)
        {

        }
            shotgunLaunch.playershot = false;
    }



    // IEnumerator RestartScene()
    // {

    // }

}

