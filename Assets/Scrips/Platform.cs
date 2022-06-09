using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] GameObject obstacle;
    GameObject frame;
    private void Awake()
    {
        obstacle.SetActive(false);
        frame = GameObject.FindGameObjectWithTag("Frame");
    }
    // Start is called before the first frame update
    void Start()
    {
        if (
            Random.Range(1, 100)%2 == 0)
        {
            obstacle.SetActive(true);
        }
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
