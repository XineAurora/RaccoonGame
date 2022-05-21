using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsBar : MonoBehaviour
{
    private Text coinsCounter;
    private Bounty playerBounty;
    // Start is called before the first frame update
    void Start()
    {
        coinsCounter = gameObject.GetComponentInChildren<Text>();
        playerBounty = GameObject.FindGameObjectWithTag("Player").GetComponent<Bounty>();
    }

    // Update is called once per frame
    void Update()
    {
        coinsCounter.text = playerBounty.Coins.ToString();
    }
}
