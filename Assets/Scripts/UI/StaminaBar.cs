using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private Image staminaBar;
    private Stamina playerStamina;
    void Start()
    {
        staminaBar = gameObject.GetComponentInChildren<Image>();
        playerStamina = GameObject.FindGameObjectWithTag("Player").GetComponent<Stamina>();
    }

    private void Update()
    {
        staminaBar.fillAmount = (float)playerStamina.CurrentStamina / playerStamina.MaximumStamina;
    }
}
