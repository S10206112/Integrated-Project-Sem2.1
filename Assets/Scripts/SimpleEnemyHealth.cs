using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleEnemyHealth : MonoBehaviour
{

    [SerializeField]
    // enemy starting hp
    public int startingHealth;
    //enemy current hp
    public int currentHealth;
    //ref to the enemy object (used for boss)
    public GameObject EnemyName;
    //ref to the minioms that would spawn when boss is attacked (used for boss)
    public GameObject Minions;
    //ref the player
    public playerEvent Player;

   

    private void Start()
    {
        
    }
    private void OnEnable()
    {
        //enemy's starting health
        currentHealth = startingHealth;
    }

    
    
    //take damage, ref from the shooting script
    public void TakeDamage(int damageAmount)
    {
        //enemy health takes damage
        currentHealth -= damageAmount;
        //debuglog enemy health
        Debug.Log(currentHealth);
        //checks if the enemy that was shot is the boss (used only for boss)
        if (EnemyName.name == "PenguinBoss")
            {
                //spawns little minions that attack the player
                Instantiate(Minions, new Vector3(70, 50, 716), Quaternion.identity);
                //debuglog minion spawned
                Debug.Log("Minions spawned");
            }

        //if the enemy is dead
        if (currentHealth <= 0)
            //triggers the Die() command
            Die();
    }
    
    private void Die()
    {
        //trigger the add kill command in the player event script
        Player.GetComponent<playerEvent>().Addkills();
        //enemy disappears
        gameObject.SetActive(false);
    }
}

    

