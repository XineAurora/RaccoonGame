using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private Canvas store;
    [SerializeField]
    private GameObject player;
    private Bounty bounty;
    [SerializeField]
    private Text staminaCost;
    [SerializeField]
    private Text healthCost;
    [SerializeField]
    private Text speedCost;

    private void Awake()
    {
        bounty = player.GetComponent<Bounty>();
        //foreach(Text text in store.GetComponentsInChildren<Text>())
        //{
        //    if(text.name == "Stamina")
        //    {
        //        staminaCost = text;
        //    }
        //    else if(text.name == "Health")
        //    {
        //        healthCost = text;
        //    }
        //    else if(text.name == "Speed")
        //    {
        //        speedCost = text;
        //    }
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        store.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinueTime()
    {
        Time.timeScale = 1;
    }

    public void BuyHealth()
    {
        if(bounty.Coins >= int.Parse(healthCost.text))
        {
            player.GetComponent<Health>().IncreaseMaxHealth(1);
            bounty.RemoveCoins(int.Parse(healthCost.text));
            healthCost.text = (int.Parse(healthCost.text) * 2).ToString();
        }
    }

    public void BuyStamina()
    {
        if (bounty.Coins >= int.Parse(staminaCost.text))
        {
            player.GetComponent<Stamina>().IncreaseMaxStamina(1);
            bounty.RemoveCoins(int.Parse(staminaCost.text));
            staminaCost.text = (int.Parse(staminaCost.text) * 2).ToString();
        }
    }

    public void BuySpeed()
    {
        if (bounty.Coins >= int.Parse(speedCost.text))
        {
            player.GetComponent<MovementBehavior>().AddMovementSpeedModifier(gameObject.ToString() + speedCost.text, 0.2f);
            bounty.RemoveCoins(int.Parse(speedCost.text));
            speedCost.text = (int.Parse(speedCost.text) * 2).ToString();
        }
    }


}
