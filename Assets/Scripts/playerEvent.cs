using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEvent : MonoBehaviour
{
    public float PlayerHealth = 100;

    public CharacterController controller;

    public Transform respawnPoint;

    public int PlayerKills = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth == 0)
        {
            Debug.Log("Player has died");
            respawn();
        }

        if (PlayerKills == 5)
        {
            Debug.Log("Quest 1 Completed : Kill 5 enemies");
        }

        
    }
    //collision with player
    void OnTriggerEnter(Collider other)
    {
        //if player collides with enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy touched player");
            //player takes damage from the attack
            TakeDamage(10);
        }
        if (other.gameObject.CompareTag("GoToShelves"))
        {
            Debug.Log("Quest 2 Complete : Go to Shelves");
            
        }
        if (other.gameObject.CompareTag("CompletedMaze"))
        {
            Debug.Log("Quest 3 Complete : Completed Maze");
            
        }
        //if player jumps on trampoline
        //if (other.gameObject.CompareTag("Trampoline"))
        //{
        //    Debug.Log("Player landed on trampoline");
            
        //}
    }
    //take damage script
    void TakeDamage(int damage)
    {
        //player health gets deducted by the damage taken
        PlayerHealth -= damage;
        
    }

    void respawn()
    {
        Debug.Log("Player has died, returning to respawn point");
        PlayerHealth = 100;
        controller.transform.position = respawnPoint.transform.position;
    }

    public void Addkills()
    {
        
        PlayerKills += 1;
        Debug.Log("Player has" + PlayerKills + "Kills");
    }
        

}
