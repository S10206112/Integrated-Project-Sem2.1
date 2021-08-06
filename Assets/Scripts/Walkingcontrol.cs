using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Walkingcontrol : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    
    //Refers to the value of the Player's initial speed
    public float speed = 6f;
    //Refers to the value of the Player's dash distance
    public float dash = 50f;
    //Refers to the value of the Player's gravity
    public float gravity = -9.81f;
    //Refers to the value of the Player's jump height
    public float jumpHeight = 1f;
    //Refers to the value of the Player's current speed
    private float currentSpeed;
    //Refers to the time it takes for the player to turn direction smoothly
    public float turnSmoothTime = 0.1f;
    //Refers to the speed it takes for the player to turn direction smoothly
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

    //public float PlayerHealth = 100;

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
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Enemy"))
    //    {
    //        Debug.Log("Enemy touched player");
    //        TakeDamage(10);
    //    }
    //}

    //void TakeDamage(int damage)
    //{
    //    PlayerHealth -= damage;
        
    //}
}
