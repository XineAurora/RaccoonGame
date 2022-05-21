using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounty : MonoBehaviour
{
    private int coins;

    private void Start()
    {
        if (PlayerPrefs.HasKey(SavingKeys.Coins))
        {
            coins = PlayerPrefs.GetInt(SavingKeys.Coins, 0);
        }
        else
        {
            coins = 0;
            PlayerPrefs.SetInt(SavingKeys.Coins, 0);
        }
        PlayerPrefs.Save();
    }

    public void AddCoins(int coins)
    {
        if (coins > 0)
        {
            this.coins += coins;
        }
    }

    public void RemoveCoins(int coins)
    {
        if (coins > 0)
        {
            this.coins -= coins;
        }
    }

    public int Coins { get { return coins; } }
}
