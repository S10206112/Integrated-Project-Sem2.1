using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    private Image HealthLength;
    public float currentHealth;
    private float MaxHealth = 100f;
    public playerEvent Player;

    private void Start()
    {
        HealthLength =  GetComponent<Image>();
        Player = FindObjectOfType<playerEvent>();

    }
    private void Update()
    {
        //syncs the player health to the current health
        currentHealth = Player.PlayerHealth;
        //fills the healthbar based on percentage of health player has
        HealthLength.fillAmount = currentHealth / MaxHealth;    
        
    }
}
