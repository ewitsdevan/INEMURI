using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Transform player;
    private SpriteRenderer playerRend;
    private Rigidbody2D playerRidg;
    public GameObject projectilePrefab;
    private AudioSource playerSound;

    public float jumpHeight;
    public float horizAxis;
    private bool isGrounded;
    private bool isJumping;
    public float playerSpeed;
    public int lastAxis;
    public float shootDelay;
    public float spriteDelay;
    private bool canShoot;

    public Sprite playerFront;
    public Sprite playerSide;
    public Sprite playerJump;
    public Sprite playerJumpSide;
    public Sprite playerStandShoot;
    public bool playerCanStandShoot = false;

    private Vector3 respawnPos;

    public int killcount;

    public AudioSource JumpClip;

    [SerializeField] GameObject pause;

    // Start is called before the first frame update
    void Start()
    {
        StaticVariables.Progress = 0;
        StaticVariables.EnemiesKilled = 0;
        respawnPos = transform.position;
        player = GetComponent<Transform>();
        playerRend = player.GetComponent<SpriteRenderer>();
        playerRidg = GetComponent<Rigidbody2D>();
        playerSound = GetComponent<AudioSource>();
        canShoot = true;
    }

    //playerMovement
    void FixedUpdate()
    {
        if (isJumping)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                lastAxis = 1;
                player.position += (new Vector3(playerSpeed / 150, 0, 0));
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                lastAxis = -1;
                player.position += (new Vector3(-playerSpeed / 150, 0, 0));
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                lastAxis = 1;
                player.position += (new Vector3(playerSpeed / 100, 0, 0));

            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                lastAxis = -1;
                player.position += (new Vector3(-playerSpeed / 100, 0, 0));
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Pause game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
            Time.timeScale = 0f;
        }

        killcount = StaticVariables.EnemiesKilled;
        // Gets key input for sprites
        horizAxis = Input.GetAxis("Horizontal");

        // Sets walking sprite if grounded
        if (isGrounded && isJumping == false)
        {
            if (horizAxis > 0)
            {
                playerRend.sprite = playerSide;
                playerRend.flipX = false;
            }
            else if (horizAxis < 0)
            {
                playerRend.sprite = playerSide;
                playerRend.flipX = true;
            }
            else if (horizAxis == 0 && Input.GetKeyDown(KeyCode.Space))
            {
                playerCanStandShoot = true;
                playerRend.sprite = playerStandShoot;
                StartCoroutine(SpriteDelay());
            }
            else if(horizAxis == 0 && playerCanStandShoot == false)
            {
                playerRend.sprite = playerFront;
            }

            // Jump
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerRidg.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
                JumpClip.Play(0);              
            }
        }
        else if (isGrounded == false && isJumping)
        {           
            // Sets jump sprite
            if (horizAxis > 0)
            {
                playerRend.sprite = playerJumpSide;
                playerRend.flipX = false;
            }
            else if (horizAxis < 0)
            {
                playerRend.sprite = playerJumpSide;
                playerRend.flipX = true;
            }
            else
            {
                playerRend.sprite = playerJump;
            }

            playerSound.Stop();
        }

        // Projectile shooting
        if(Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            canShoot = false;           
            StartCoroutine(ShootDelay());            
        }

        if (horizAxis != 0)
        {
            if (playerSound.isPlaying == false)
            {
                playerSound.Play();
            }
        }
        else
        {
            playerSound.Stop();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Checkpoints
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            respawnPos = collision.gameObject.transform.position;
            StaticVariables.Progress += 0.25f;
            Destroy(collision.gameObject);
        }
    }

    // While collision exists
    public void OnTriggerStay2D(Collider2D collision)
    {
        // Sets sprite as walking
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
        }

        // Respawn when player falls
        if (collision.gameObject.CompareTag("Respawn"))
        {
            SceneManager.LoadScene("GameOverScene");
        }

        // Game over scene when player dies
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    // When collision exits
    public void OnTriggerExit2D(Collider2D collision)
    {
        // Sets jump as true when player isn't touching the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            isJumping = true;
        }
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSecondsRealtime(shootDelay);
        canShoot = true;
    }

    IEnumerator SpriteDelay()
    {
        yield return new WaitForSecondsRealtime(spriteDelay);
        playerCanStandShoot = false;
    }
}
