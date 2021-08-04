using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Walkingcontrol : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float dash = 50f;
    public float gravity = -9.81f;
    public float jumpHeight = 1f;
    private float currentSpeed;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    [SerializeField]
    private AudioSource JumpSource;
    
    [SerializeField]
    private AudioSource SprintSource;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    

    // Update is called once per frame
    void Update()
    {
        //creating a sphere at the bottom of the player to detect if theres any ground below
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //makes the player remain on the ground and not fall through the floor
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }

        //the basic WASD player controls
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * currentSpeed * Time.deltaTime);

        //jumping
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            JumpSource.Play();
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //var horizontal = Input.GetAxisRaw("Horizontal");
        //var vertical = Input.GetAxisRaw("Vertical");


        Vector3 direction = new Vector3(x, 0f, z);

        //sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SprintSource.Play();
            currentSpeed = speed * dash;
        }
        else
        {
            currentSpeed = speed;
        }

        


        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
        }




    }
}
