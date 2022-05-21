using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaRestore : MonoBehaviour
{
    [SerializeField]
    private int StaminaRestoreValue = 0;
    [SerializeField]
    private new GameObject audio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Stamina>().RestoreStamina(StaminaRestoreValue);
            Instantiate(audio, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
