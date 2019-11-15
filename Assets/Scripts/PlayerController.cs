using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float moveVelocityY, moveVelocityX;
    public float speed;
    public Camera cam;
    private GameObject gob;

    private Animator Anim;

    public GameObject retryButton;
    
    public Canvas UiStuff;
    //this is the menu script

    private NewBehaviourScript behave;

    private bool gameActive = true;

    private AudioSource AudioSource;

    public AudioClip DieClip;
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.clip = DieClip;


        gob = new GameObject();
        Anim = GetComponent<Animator>();
        behave = UiStuff.GetComponent<NewBehaviourScript>();
    }
   


    private void FixedUpdate()
    {
        moveVelocityY = 0;
        moveVelocityX = 0;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Anim.ResetTrigger("Idle");
            Anim.SetTrigger("Walk");
            moveVelocityX = -speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Anim.ResetTrigger("Idle");
            Anim.SetTrigger("Walk");
            moveVelocityX = speed;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Anim.ResetTrigger("Idle");
            Anim.SetTrigger("Walk");
            moveVelocityY = speed;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            Anim.ResetTrigger("Idle");
            Anim.SetTrigger("Walk");
            moveVelocityY = -speed;
        }



        //Key ups for changin back to idle
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {

            Anim.SetTrigger("Idle");
            Anim.ResetTrigger("Walk");
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            Anim.ResetTrigger("Walk");
            Anim.SetTrigger("Idle");
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            Anim.ResetTrigger("Walk");
            Anim.SetTrigger("Idle");
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            Anim.ResetTrigger("Walk");
            Anim.SetTrigger("Idle");
        }



        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, moveVelocityY);



        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocityX, GetComponent<Rigidbody2D>().velocity.y);

        gob.transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
        // point our object at the dummy object

       // transform.LookAt(gob.transform, Vector3.forward);


        Vector3 vectorToTarget = gob.transform.position - transform.position;
        float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) + 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);

       
        

    }


    //called from the enemy to end the game
    public void endGame()
    {
        
        if (gameActive)
        {
            AudioSource.clip = DieClip;
            AudioSource.Play();
            gameActive = false;
            retryButton.SetActive(true);
            behave.fade();

        }
    }




}
