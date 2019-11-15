using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    [SerializeField] Transform playerPosition;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which Enemy walks to the next one
   
    private int waypointIndex = 0;

    //the position that the enemy left its pathing
    private Transform PositionLeftPat;

    //speed of the turn 
    public float speed, chaseSpeed;

    private bool ChaseEnabled;

    private Animator anim;

    public LayerMask mask;

    private AudioSource AudioSource;

    public AudioClip roarClip;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.clip = roarClip;

        anim = GetComponent<Animator>();
        // Set position of Enemy as position of the first waypoint

        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (ChaseEnabled)
        {
            //chasing function
            chase();

        }
        else
        {
            // Move Enemy
            Move();
        }

    }

    // Method that actually make Enemy walk
    private void Move()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops
        if (waypointIndex <= waypoints.Length - 1)
        {
            //finds the angle of rotation towards the next point and turns the sprite towards it.
            Vector3 vectorToTarget = waypoints[waypointIndex].transform.position - transform.position;
            float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg)+90;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);

            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector2.MoveTowards(transform.position,
               waypoints[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                print("reached point");
                waypointIndex += 1;
                //if the last waypoint is reached then cycle index back to the first 

                if( waypointIndex == waypoints.Length-1)
                {
                    print("final node reached");
                    waypointIndex = 0;
                }
            }
        }
    }

    private void chase()
    {
        Vector3 vectorToTarget = playerPosition.position - transform.position;
        float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) + 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);

        transform.position = Vector2.MoveTowards(transform.position,
              playerPosition.position,
              chaseSpeed * Time.deltaTime);

        RaycastHit2D hit;

         hit = Physics2D.Raycast(transform.position,  playerPosition.position - transform.position ,700,LayerMask.GetMask("Player"));

      
        //this might not do anything
        if (hit.collider != null)
        {
           

            print(hit.collider.tag);

            if(hit.collider.gameObject.tag == "Player")
            {

            }
            else
            {
                endChase();
            }
        }
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, playerPosition.position - transform.position, 14, LayerMask.GetMask("Player"));

        

        if (hit.collider != null && hit.collider.gameObject.tag=="Player")
        {
            if (hit.collider.gameObject.tag == "Player"&& ChaseEnabled == false)
            {
                print("seeing player");
                startChase();
            }
            else
            {
                
                print("player out of sight");
            }
        }
        else
        {
            endChase();
        }
    }


   

    public void startChase()
    {
        
        ChaseEnabled = true;
        anim.SetTrigger("Chase");
        playRoar();
        anim.ResetTrigger("StopChase");
        // play anim and sounds so signify the player has been caught

    }

    public void endChase()
    {
        ChaseEnabled = false;
        anim.ResetTrigger("Chase");
        anim.SetTrigger("StopChase");
    }

    public void playRoar()
    {
        AudioSource.Play();
    }
}
