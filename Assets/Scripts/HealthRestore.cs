using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRestore : MonoBehaviour
{
    [SerializeField]
    private int healValue;
    [SerializeField]
    private new GameObject audio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().Heal(healValue);
            Instantiate(audio, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
