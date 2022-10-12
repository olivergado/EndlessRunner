using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject groundChecker;
    public LayerMask whatIsGround;

    public AudioClip jump;
    public AudioClip backgroundMusic;

    public AudioSource sfxPlayer;
    public AudioSource musicPlayer;


    float maxSpeed = 5.0f;
    bool isOnGround = false;

    public float jumpForce = 100.0f;

    Animator anim;

    Rigidbody2D playerObject;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //float movementValueX = Input.GetAxis("Horizontal");
        float movementValueX = 1.0f;

        playerObject.velocity = new Vector2(movementValueX * maxSpeed, playerObject.velocity.y);
        playerObject.velocity = new Vector2(movementValueX * maxSpeed, playerObject.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 1.0f, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            playerObject.AddForce(new Vector2(0.0f, jumpForce));
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            maxSpeed = 10.0f;
        }else
        {
            maxSpeed = 5.0f;
        }

        anim.SetFloat("Speed", Mathf.Abs(movementValueX));
        anim.SetBool("IsOnGround", isOnGround);

        musicPlayer.clip = backgroundMusic;
        musicPlayer.loop = true;
        musicPlayer.Play();
        sfxPlayer.PlayOneShot(jump);

    }
}
