using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    private MovementBehavior movement;
    private int currentStamina;
    private int maximumStamina;
    private bool canSpendStamina = true;
    private bool addedMsModifier = false;
    private bool regenStarted = false;
    [SerializeField]
    private float spendTimeout = 3f;
    [SerializeField]
    private float regenTimeout = 4f;
    [SerializeField]
    private float msModifier = -0.3f;

    public int CurrentStamina { get { return currentStamina; } }
    public int MaximumStamina { get { return maximumStamina; } }

    private void Start()
    {
        movement = gameObject.GetComponent<MovementBehavior>();
        maximumStamina = PlayerPrefs.GetInt(SavingKeys.MaxStamina, 10);
        currentStamina = maximumStamina;
    }

    private void FixedUpdate()
    {
        if (movement.IsMoving && canSpendStamina)
        {
            StopCoroutine(RegenStamina());
            regenStarted = false;
            StartCoroutine(SpendTimeout());
            if (currentStamina > 0)
            {
                currentStamina--;
            }
            if(currentStamina==0 && !addedMsModifier)
            {
                movement.AddMovementSpeedModifier(this.ToString(), msModifier);
                addedMsModifier = true;
            }
            if (currentStamina > 0 && addedMsModifier)
            {
                movement.RemoveMovementSpeedModifier(this.ToString());
                addedMsModifier = false;
            }
        }
        else if (!movement.IsMoving && !regenStarted)
        {
            StartCoroutine(RegenStamina());
        }
    }

    public void RestoreStamina(int value)
    {
        if (value > 0)
        {
            currentStamina = Mathf.Min(maximumStamina, currentStamina + value);
        }
    }

    public void IncreaseMaxStamina(int value)
    {
        maximumStamina += value;
        currentStamina = maximumStamina;
    }

    private IEnumerator SpendTimeout()
    {
        canSpendStamina = false;
        yield return new WaitForSeconds(spendTimeout);
        canSpendStamina = true;
    }

    private IEnumerator RegenStamina()
    {
        regenStarted = true;
        yield return new WaitForSeconds(regenTimeout);
        if (!movement.IsMoving)
        {
            RestoreStamina(1);
        }
        regenStarted = false;
    }
}
