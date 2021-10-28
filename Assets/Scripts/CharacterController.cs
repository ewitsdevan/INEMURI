using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    private Transform player;
    private SpriteRenderer playerRend;
    private Rigidbody2D playerRidg;

    public float jumpHeight;
    public float horizAxis;
    private bool isGrounded;
    private bool isJumping;
    public float speed;

    public Sprite playerFront;
    public Sprite playerSide;
    public Sprite playerJump;
    public Sprite playerJumpSide;
    public Sprite playerLand;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        playerRend = player.GetComponent<SpriteRenderer>();
        playerRidg = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        // Gets key input for sprites
        horizAxis = Input.GetAxis("Horizontal");
        

        if (isJumping)
        {
            if (Input.GetKey(KeyCode.D))
            {
                player.position += (new Vector3(speed / 150, 0, 0));
            }

            if (Input.GetKey(KeyCode.A))
            {
                player.position += (new Vector3(-speed / 150, 0, 0));
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                player.position += (new Vector3(speed / 100, 0, 0));
            }
            
            if (Input.GetKey(KeyCode.A))
            {
                player.position += (new Vector3(-speed / 100, 0, 0));
            }
        }
        


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
            else
            {
                playerRend.sprite = playerFront;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRidg.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
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
        }

        // Projectile shooting
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }

    // While collision exists
    public void OnTriggerStay2D(Collider2D collision)
    {
        // Sets sprite as landing when player touches ground after jump
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

            if(isJumping)
            {
                playerRend.sprite = playerLand;
                isJumping = false;
            }
        }

        if (collision.gameObject.CompareTag("Respawn"))
        {
            SceneManager.LoadScene("GameScene");
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(0);
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
}
