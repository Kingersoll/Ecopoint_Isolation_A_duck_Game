using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChhDoor : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("what what");
        if (collision.gameObject.tag == "Player")
        {
            print("what");
            anim.SetTrigger("Enter Door");
            anim.ResetTrigger("Leave Door");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.ResetTrigger("Enter Door");
            anim.SetTrigger("Leave Door");
        }
    }
}
