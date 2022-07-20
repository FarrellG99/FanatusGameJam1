using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator pAnimator;
    private Rigidbody rigidbody;
    //private CharacterController controller;
    private Vector3 direction;
    private float counter = 0;
    private int desiredLane = 0; //-1 : left 0 : middle 1 : right

    public float forwardSpeed;
    public float laneDistance; //distance between each lanes
    public float jumpForce; //jump force
    public float gravity; //gravity

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        //controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;
        pAnimator.SetBool("Run", true);

        movementControl();
        movedLane();

        checkJump();
    }

    //moving player using direction
    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + direction);
        //rigidbody.velocity = direction;
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
                counter = 10;
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
                counter = 10;
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

        transform.position = Vector3.Lerp(transform.position, targetPosition, (counter / 10) * Time.fixedDeltaTime);
        counter++;
    }

    private void checkJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
            pAnimator.SetTrigger("Jump");
        }
    }

    private void jump()
    {
        rigidbody.velocity = Vector3.up * jumpForce;
    }
}
