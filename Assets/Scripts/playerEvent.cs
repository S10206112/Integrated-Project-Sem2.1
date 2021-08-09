using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEvent : MonoBehaviour
{
    public float PlayerHealth = 100;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

}
