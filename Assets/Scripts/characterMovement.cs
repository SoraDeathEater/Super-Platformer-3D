using UnityEngine;

public class characterMovement : MonoBehaviour
{
    // Initialization

    [SerializeField] float speed = 1;
    [SerializeField] float jumpForce = 1;
    [SerializeField] float gravity = 1;

    [SerializeField] Transform myCamera;

    [SerializeField] Animator myAnimator;

    CharacterController controller;
    Vector3 movement;

    bool grounded;
    
    void Start()
    {
        // Setting up Controller Variable at Start of Area
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // PLayer Input
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        if(xInput != 0 || yInput != 0)
        {
            myAnimator.SetBool("IsRunning", true);
        }
        else
        {
            myAnimator.SetBool("IsRunning", false);
        }


            // Camera Angle
            Vector3 camForward = myCamera.forward;
        Vector3 camRight = myCamera.right;

        camForward.y = 0;
        camForward.Normalize();

        camRight.y = 0;
        camRight.Normalize();

        // Changing the Camera Angle depending on Player movement
        Vector3 forwardRelativeMovementVector = yInput * camForward;
        Vector3 rightRelativeMovementVecore = xInput * camRight;


        // Character Movement - Its going to use Camera Movement for the character movement
        //movement.x = xInput * speed; 
        //movement.z = yInput * speed;
        var relativeMovement = (forwardRelativeMovementVector + rightRelativeMovementVecore) * speed;

        if (xInput != 0 && yInput != 0) // Having the character match the direction facing
            transform.forward = relativeMovement;

        relativeMovement.y = movement.y;
        movement = relativeMovement;

        movement.y += gravity * Time.deltaTime;


        // Allowing for Gravity Pull and Jumping Variables
        if (controller.isGrounded)
            movement.y = 0;

        grounded = Physics.Raycast(transform.position + Vector3.down, Vector3.down, 1);

        myAnimator.SetBool("onGround", grounded);


        // Character Jumping
        if(Input.GetButtonDown("Jump") && grounded) //Doesn't need to have the == true to be true. It'll automatically be true. 
        {
            movement.y = jumpForce;
            myAnimator.SetTrigger("jump");
        }
        controller.Move(movement * Time.deltaTime);

        

    }
}
