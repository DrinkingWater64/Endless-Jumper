using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Platform : MonoBehaviour
{


    GameObject frame;
    private void Awake()
    {
        frame = GameObject.FindGameObjectWithTag("Frame");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Frame"))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * frame.GetComponent<Frame>().speed * Time.deltaTime);
    }
}
