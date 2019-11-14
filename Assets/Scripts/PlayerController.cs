using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float moveVelocityY, moveVelocityX;
    public float speed;
    public Camera cam;
    private GameObject gob;

    private Animator Anim;

    //void Start(){
    //anim = GetComponent<Animator> ();
    //}
    void Start()
    {
        gob = new GameObject();
        Anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
      

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
            print("keyUp");
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
        SceneManager.LoadScene(0);
        print("get shit on kid you suck hehehe");
    }


}
