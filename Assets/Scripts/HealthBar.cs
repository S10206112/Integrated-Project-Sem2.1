using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    private Image HealthLength;
    public float currentHealth;
    private float MaxHealth = 100f;
    Walkingcontrol Player;

    private void Start()
    {
        HealthLength =  GetComponent<Image>();
        Player = FindObjectOfType<Walkingcontrol>();

    }
    private void Update()
    {
        currentHealth = Player.PlayerHealth;
        HealthLength.fillAmount = currentHealth / MaxHealth;
    }
}
