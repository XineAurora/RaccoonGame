using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : BasicEnemy
{
    private Animator animator;
    private new AudioSource audio;
    private void Start()
    {
        animator = GetComponent<Animator>();
        aggroRadius = 0f;
        audio = GetComponent<AudioSource>();
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && canChase)
        {
            collision.gameObject.GetComponent<Health>().Damage(damage);
            animator.SetTrigger("Activate");
            StartCoroutine(ChaseCooldown());
            audio.Play();
        }
        else if(collision.gameObject.tag == "Enemy" && canChase && collision.gameObject.layer != LayerMask.NameToLayer("Hunter"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().Damage(damage);
            animator.SetTrigger("Activate");
            StartCoroutine(ChaseCooldown());
            audio.Play();
        }
    }
}
