using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealthBar : MonoBehaviour
{
    private Image HealthLength;
    public float currentHealth;
    public float MaxHealth = 100;
    public SimpleEnemyHealth Enemy;

    private void Start()
    {
        HealthLength =  GetComponent<Image>();
       
    }
    private void Update()
    {
        currentHealth = Enemy.currentHealth;
        HealthLength.fillAmount = currentHealth / MaxHealth;    
        
    }
}