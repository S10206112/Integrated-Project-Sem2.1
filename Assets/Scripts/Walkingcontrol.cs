using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Walkingcontrol : MonoBehaviour
{
    //refers to the player's controller
    public CharacterController controller;
    //refers to the player's rotating camera
    public Transform cam;

    public playerEvent playerEvent;
    
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

    //refers to the object that checks if there is ground below the player
    public Transform groundCheck;
    //refers to the distance from the ground that would consider the object is grounded
    public float groundDistance = 0.4f;
    //refers to the layer which is considered as ground
    public LayerMask groundMask;
    //refers to the velocity
    Vector3 velocity;
    //bool for when the player is grounded
    bool isGrounded;

    public Transform teleportToBox;

    public Transform teleportToTrain;

    //refers to the audio source for player's jump
    [SerializeField]
    private AudioSource JumpSource;
    


    //public float PlayerHealth = 100;

    Animator animator;

    void Start()
    {
        //define what is the character controller
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
            
            currentSpeed = speed * dash;
            playerEvent.PlayerHealth -= 5;
        }
        //if the player is not sprinting
        else
        {
            currentSpeed = speed;
        }

        

        //if the player is moving in a certain direction, moves the character object to face that direction
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
        }




    }
    void OnTriggerEnter(Collider other)
    {
        //if player jumps on trampoline
        if (other.gameObject.CompareTag("Trampoline"))
        {
            Debug.Log("Player landed on trampoline");
            jumpHeight = 80;    
        }
        else 
        {
            jumpHeight = 8;
        }

        if (other.gameObject.CompareTag("TeleportToBox"))
        {
            Debug.Log("Teleported to Box");
            //player teleports to Box
            controller.transform.position = teleportToBox.transform.position;
        }
        if (other.gameObject.CompareTag("TeleportToTrain"))
        {
            Debug.Log("Teleported to Train");
            //player teleports to train
            controller.transform.position = teleportToTrain.transform.position;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Trampoline"))
        {
            Debug.Log("Player has left the trampoline");
            jumpHeight = 8;    
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
