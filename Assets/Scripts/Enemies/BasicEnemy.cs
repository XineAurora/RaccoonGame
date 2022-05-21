using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField]
    protected int damage = 0;
    [SerializeField]
    protected float movementSpeed = 1;
    [SerializeField]
    protected float aggroRadius = 1;
    [SerializeField]
    protected float chaseCooldown = 1;

    protected GameObject player;
    protected new Rigidbody2D rigidbody;
    protected bool canChase = true;

    private void Awake()
    {
        Start();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= aggroRadius && canChase)
        {
            ChasePlayer();
        }
    }

    protected virtual void ChasePlayer()
    {
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().Damage(damage);
            StartCoroutine(ChaseCooldown());
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().Damage(damage);
            StartCoroutine(ChaseCooldown());
        }
    }

    protected IEnumerator ChaseCooldown()
    {
        canChase = false;
        yield return new WaitForSeconds(chaseCooldown);
        canChase = true;
    }
}
