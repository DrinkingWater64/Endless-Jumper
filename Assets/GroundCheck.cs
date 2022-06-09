using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] Animator anim;
    public bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            // StopCoroutine(SetFalse());
            isGrounded = true;
            anim.SetBool("StartJump", false);
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            if (isGrounded == true)
            {
                StartCoroutine(SetFalse());
            }
            anim.SetBool("StartJump", true);
        }
    }

    void SetIsGrounded(bool term)
    {
        isGrounded = term;
    }


    IEnumerator SetFalse()
    {
        if (isGrounded == false)
        {
            yield return null;
        }
        else if (isGrounded == true)
        {
            yield return new WaitForSeconds(.2f);
            isGrounded = false;
        }

    }

}
