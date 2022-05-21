using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leafs : MonoBehaviour
{
    [SerializeField]
    private GameObject coin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            coin.GetComponent<GoldCoin>().CreateCoin(gameObject.transform.position);
            Destroy(gameObject);
        }
    }
}
