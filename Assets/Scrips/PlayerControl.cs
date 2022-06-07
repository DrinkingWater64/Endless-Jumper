using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float _speed = .5f;
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    float _force;

    float fallMultiplier = 3.5f;
    float lowJumpMultiplier = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalT = Input.GetAxis("Horizontal");
        float verticalT = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(horizontalT, verticalT);

        //transform.Translate(horizontalT, 0, 0);
        Walk(dir);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(dir);
        }

        if (rb.velocity.y<0)
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
        Debug.Log("jump");
        rb.velocity = new Vector2(dir.x, 0);
        rb.velocity += Vector2.up * _force;
    }

    void Walk( Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * _speed , rb.velocity.y);
    }

    private void FixedUpdate()
    {
    }
}
