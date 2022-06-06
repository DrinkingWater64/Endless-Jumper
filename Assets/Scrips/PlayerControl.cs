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
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalT = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;
        transform.Translate(horizontalT, 0, 0);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jump");
            rb.AddForce(Vector2.up * _force, ForceMode2D.Force);
        }


    }

    private void FixedUpdate()
    {
    }
}
