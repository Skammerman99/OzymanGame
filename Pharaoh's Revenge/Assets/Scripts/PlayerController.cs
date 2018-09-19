using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float moveSpeed;
    public float jumpHeight;

    public Transform groundCheck, leftTopCheck, rightTopCheck, leftBotCheck, rightBotCheck;
    public float groundCheckRadius;
    public LayerMask ground;
    public bool grounded, leftWalled, rightWalled;

    public GameObject spawnPrefab;
    float timer = 0f;


    // Use this for initialization
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        timer = 0f;

    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);
        leftWalled = Physics2D.OverlapCircle(leftTopCheck.position, groundCheckRadius, ground) || (Physics2D.OverlapCircle(leftBotCheck.position, groundCheckRadius, ground) && !grounded);
        rightWalled = Physics2D.OverlapCircle(rightTopCheck.position, groundCheckRadius, ground) || (Physics2D.OverlapCircle(rightBotCheck.position, groundCheckRadius, ground) && !grounded);

    }

    void SpawnMe()
    {
        GameObject swing = (GameObject)Instantiate(spawnPrefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update() {

        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && !rightWalled)
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        }
        else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && !leftWalled)
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        }


        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && grounded)
        {
            rb2d.velocity = new Vector2(0, jumpHeight);
        }
    }
}
