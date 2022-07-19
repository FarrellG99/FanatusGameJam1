using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private float counter = 0;
    private int desiredLane = 0; //-1 : left 0 : middle 1 : right

    public float laneDistance; //distance between each lanes
    public float jumpForce; //jump force
    public float gravity; //gravity

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;        

        movementControl();
        movedLane();

        checkJump();
    }

    //moving player using direction
    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }

    //checking button pressed for movement
    private void movementControl()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;

            if (desiredLane == 2)
            {
                desiredLane = 1;
                counter = 100;
            }
            else
            {
                counter = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;

            if (desiredLane == -2)
            {
                desiredLane = -1;
                counter = 100;
            }
            else
            {
                counter = 0;
            }
        }


    }

    //to move player to another lane
    private void movedLane()
    {
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        targetPosition.x += desiredLane * laneDistance;

        //transform.position = targetPosition;

        transform.position = Vector3.Lerp(transform.position, targetPosition, (counter/100));
        counter++;

        //transform.Translate(targetPosition);
    }

    private void checkJump()
    {
        if (controller.isGrounded)
        {
            direction.y = -1;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump();
            }
        }
        else
        {
            direction.y = gravity;
        }
    }

    private void jump()
    {
        direction.y = jumpForce;
        print("Jumped = " + direction);
    }
}
