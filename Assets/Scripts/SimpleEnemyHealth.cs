using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyHealth : MonoBehaviour
{

    [SerializeField]
    private int startingHealth = 5;

    private int currentHealth;
    public GameObject EnemyName;
    
    public GameObject Minions;

    private void OnEnable()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log(currentHealth);
        if (EnemyName.name == "PenguinBoss")
            {
                Instantiate(Minions, new Vector3(80, 100, 575), Quaternion.identity);
                Debug.Log("Minions spawned");
            }

        //if the enemy is dead
        if (currentHealth <= 0)
            Die();
    }
    
    private void Die()
    {
        gameObject.SetActive(false);
    }
}

