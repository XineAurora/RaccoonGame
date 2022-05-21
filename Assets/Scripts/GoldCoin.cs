using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    [SerializeField]
    private int wealth = 1;
    [SerializeField]
    private new GameObject audio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(audio, gameObject.transform.position, Quaternion.identity);
            collision.GetComponentInParent<Bounty>().AddCoins(this.wealth);
            Destroy(this.gameObject);
        }
    }

    public void CreateCoin(Vector3 position)
    {
        Instantiate(this.gameObject, position, Quaternion.identity);
    }
}
