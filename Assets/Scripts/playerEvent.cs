using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerEvent : MonoBehaviour
{
    //ref of the player's health
    public float PlayerHealth = 100;

    //ref the character controller
    public CharacterController controller;

    //ref to respawn point
    public Transform respawnPoint;

    //ref for number of kills the player has
    public int PlayerKills = 0;

    //to ref the penguin boss
    public GameObject PenguinBoss;

    public Animator QuestLog;
    public GameObject Quest1;
    public GameObject Quest2;
    public GameObject Quest3;
    public GameObject Quest4;
    public GameObject Quest5;




    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if player health reaches zero
        if (PlayerHealth == 0)
        {
            //debug that player is dead
            Debug.Log("Player has died");
            //trigger the respawn function
            respawn();
        }

        //Quest Completion conditions
        //if the player gets 5 kills
        if (PlayerKills == 3)
        {
            //debuglog
            Debug.Log("Quest 1 Completed : Kill 3 enemies");
            QuestLog.SetBool("SeeQuest", true);
            Quest1.SetActive(true);

        }
        // if the boss has been defeated
        if (PenguinBoss.activeInHierarchy == false)
        {
            //debuglog
            Debug.Log("Quest 5 Completed : Penguin Boss defeated");
            Quest5.SetActive(true);
            SceneManager.LoadScene ("YouWin");
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
        //when player reaches the shelves section of the game
        if (other.gameObject.CompareTag("GoToShelves"))
        {
            //debuglog
            Debug.Log("Quest 2 Complete : Go to Shelves");
            QuestLog.SetBool("SeeQuest", true);
            Quest2.SetActive(true);
        }
        //when player reaches the end of the maze
        if (other.gameObject.CompareTag("CompletedMaze"))
        {
            //debuglog
            Debug.Log("Quest 3 Complete : Completed Maze");
            QuestLog.SetBool("SeeQuest", true);
            Quest3.SetActive(true);
        }
        //when player reaches the end of the maze
        if (other.gameObject.CompareTag("CompletedTrain"))
        {
            //debuglog
            Debug.Log("Quest 4 Complete : Completed Train");
            QuestLog.SetBool("SeeQuest", true);
            Quest4.SetActive(true);
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

    //respawn script
    void respawn()
    {
        //debuglog
        Debug.Log("Player has died, returning to respawn point");
        //resets player health to full
        //PlayerHealth = 100;
        //resets player position to respawn point
        //controller.transform.position = respawnPoint.transform.position;
        SceneManager.LoadScene ("GameOver");
    }

    //tallying the num of kills the player has
    public void Addkills()
    {
        //add a kill
        PlayerKills += 1;
        //debuglog
        Debug.Log("Player has" + PlayerKills + "Kills");
    }
        

}
