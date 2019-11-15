using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChhDoor : MonoBehaviour
{
    private Animator anim;


    private AudioSource AudioSource;

    public AudioClip ChhClip;

    private void Start()
    {
        AudioSource = gameObject.GetComponent<AudioSource>();
        AudioSource.clip = ChhClip;
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            AudioSource.Play();
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
