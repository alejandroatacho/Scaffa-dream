using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour

{
    private const float LANE_DISTANCE = 3.0f;
    private const float TURN_SPEED = 0.05f;

    // Animation
    private Animator anim;

    //Movement
    private CharacterController controller;
    private float jumpForce = 4.0f;
    private float gravity = 12.0f;
    private float VerticalVelocity;
    private float speed = 7.0f;
    private int desiredLane = 1; //0 = Left, 1 = Middle, 2 = Right

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //Gather the input on which lane we should be
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            MoveLane(false);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            MoveLane(true);

        //Calculate where we should be in the future
        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (desiredLane == 0)
            targetPosition += Vector3.left * LANE_DISTANCE;
        else if (desiredLane == 2)
            targetPosition += Vector3.right * LANE_DISTANCE;

        //Calculate our move delta
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * speed;

        bool isGrounded = IsGrounded();
        anim.SetBool("Grounded", isGrounded);
        
        //Calculate Y
        if (controller.isGrounded) 
        {
            VerticalVelocity = -0.1f;
          
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Jump
                anim.SetTrigger("Jump");
                VerticalVelocity = jumpForce;
            }
        }
        else
        {
            VerticalVelocity -= (gravity * Time.deltaTime);

            //fast fall
            if (Input.GetKeyDown(KeyCode.Space))
            {
                VerticalVelocity = -jumpForce;
            }
        }

        moveVector.y = VerticalVelocity;
        moveVector.z = speed;

        //Move the Dino
        controller.Move(moveVector * Time.deltaTime);

        //Rotate the Dino to where he is going
        Vector3 dir = controller.velocity;
        dir.y = 0;
        //transform.forward = dir; Sweet sideway movement!!
        transform.forward = Vector3.Lerp(transform.forward,dir, TURN_SPEED);
    }

  

    private void MoveLane(bool goingRight)
    {
        desiredLane += (goingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
    }

    private bool IsGrounded()
    {
       Ray groundRay = new Ray(new Vector3(controller.bounds.center.x,(controller.bounds.center.y - controller.bounds.extents.y) + 0.2f,controller.bounds.center.z),Vector3.down);

        return (Physics.Raycast(groundRay, 0.2f + 0.1f));

    }
}
