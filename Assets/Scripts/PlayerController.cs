using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float moveVelocityY, moveVelocityX;
    public float speed;
    public Camera cam;
    private GameObject gob;


    //void Start(){
    //anim = GetComponent<Animator> ();
    //}
    void Start()
    {
        gob = new GameObject();
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
            moveVelocityX = -speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveVelocityX = speed;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            moveVelocityY = speed;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            moveVelocityY = -speed;
        }

        if (Input.GetMouseButtonDown(0))
        {

      

        }


        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, moveVelocityY);



        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocityX, GetComponent<Rigidbody2D>().velocity.y);

        gob.transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
        // point our object at the dummy object

        transform.LookAt(gob.transform, Vector3.forward);



    }
}
