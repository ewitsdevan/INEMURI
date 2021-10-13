using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Transform player;
    private SpriteRenderer playerRend;
    private Rigidbody2D playerRidg;
    private float horizAxis;

    public Sprite playerFront;
    public Sprite playerSide;
    public Sprite playerJump;
    public Sprite playerJumpSide;
    public Sprite playerLand;

    public float jumpHeight;
    public bool isGrounded;
    public bool isJumping;

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
        horizAxis = Input.GetAxis("Horizontal");
        player.position += (new Vector3(horizAxis, 0, 0))/30;

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
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

            if(isJumping)
            {
                playerRend.sprite = playerLand;
                isJumping = false;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            isJumping = true;
        }
    }
}
