using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] SpriteRenderer playerSprite;
    [SerializeField] float _speed = .5f;
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    float _force;

    [SerializeField]
    GameObject groundChecker;

    [SerializeField]
    Animator planimator;
    bool canJump = false;


    float fallMultiplier = 4f;
    float lowJumpMultiplier = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        canJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalT = Input.GetAxis("Horizontal");
        if (horizontalT > 0)
        {
            planimator.SetBool("StartRun", true);
            playerSprite.flipX = true;
        }
        else if (horizontalT < 0)
        {
            planimator.SetBool("StartRun", true);
            playerSprite.flipX = false;
        }
        else if (horizontalT == 0)
        {
            planimator.SetBool("StartRun", false);
        }

        float verticalT = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(horizontalT, verticalT);

        //transform.Translate(horizontalT, 0, 0);
        Walk(dir);



        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (groundChecker.GetComponent<GroundCheck>().isGrounded == true)
            {
                Jump(dir);
                planimator.SetBool("StartJump", false);
            }
        }


        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }



    }

    void Jump(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x, 0);
        rb.velocity += Vector2.up * _force;
    }

    void Walk(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * _speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GameOver"))
        {
            GameState.instance.GameOver();
        }
        if (collision.gameObject.CompareTag("platform"))
        {
            if (canJump == false)
            {
                Debug.Log(canJump + " alterd anim");
                planimator.SetBool("StartJump", false);
            }
            canJump = true;
        }
    }


}
