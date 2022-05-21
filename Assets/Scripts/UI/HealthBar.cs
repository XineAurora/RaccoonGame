using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    private Health playerHealth;

    private void Start()
    {
        healthBar = gameObject.GetComponentInChildren<Image>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    private void Update()
    {
        healthBar.fillAmount = (float)playerHealth.CurrentHealth / playerHealth.MaxHealth;
    }

}
