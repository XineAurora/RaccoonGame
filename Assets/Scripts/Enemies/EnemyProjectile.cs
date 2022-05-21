using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lifeTime;
    [SerializeField]
    private new GameObject audio;

    private new Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(LifeTimer());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Hunter"))
        {
            if (collision.tag == "Player" )
            {
                    collision.gameObject.GetComponent<Health>().Damage(damage);
            }
            else if(collision.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyHealth>().Damage(damage);
            }
            if (collision.tag != "Coin" && collision.tag != "Meal")
            {
                Instantiate(audio, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 direction = new Vector2(1, 0);
        direction.Normalize();
        direction *= speed;
        rigidbody.transform.Translate(direction * Time.fixedDeltaTime);
    }

    private IEnumerator LifeTimer()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
