using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealthBar : MonoBehaviour
{
    //ref enemy healthbar
    private Image HealthLength;
    //currenthealth
    public float currentHealth;
    //maxhealth of enemy
    public float MaxHealth = 100;
    //ref the enemy
    public SimpleEnemyHealth Enemy;

    private void Start()
    {
        //get component of healthbar
        HealthLength =  GetComponent<Image>();
       
    }
    private void Update()
    {
        //sync the currenthealth here to the enemy's current health
        currentHealth = Enemy.currentHealth;    
        
        HealthLength.fillAmount = currentHealth / MaxHealth;    
        
    }
}