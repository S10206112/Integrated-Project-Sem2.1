using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealthBar : MonoBehaviour
{
    private Image HealthLength;
    public float currentHealth;
    private float MaxHealth = 100f;
    public SimpleEnemyHealth Enemy;

    private void Start()
    {
        HealthLength =  GetComponent<Image>();
        Enemy = FindObjectOfType<SimpleEnemyHealth>();

    }
    private void Update()
    {
        currentHealth = Enemy.startingHealth;
        HealthLength.fillAmount = currentHealth / MaxHealth;    
        
    }
}