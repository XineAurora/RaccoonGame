using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : BasicEnemy
{
    [SerializeField]
    protected float armingTime = 1f;
    [SerializeField]
    protected GameObject projectile;
    private bool canShoot = true;
    private Animator animator;
    private new AudioSource audio;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    protected override void ChasePlayer()
    {
        if (canShoot)
        {
            animator.SetTrigger("Shoot");
            StartCoroutine(ArmingTimer());
        }
    }

    protected void Shoot(Vector2 direction)
    {
        audio.Play();
        direction.Normalize();
        float rotation = Mathf.Atan2(direction.y, direction.x);
        Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0, 0, rotation * 180 / Mathf.PI)));
    }

    protected IEnumerator ArmingTimer()
    {
        canShoot = false;
        yield return new WaitForSeconds(armingTime);
        animator.SetTrigger("StopShoot");
        if (Vector2.Distance(transform.position, player.transform.position) <= aggroRadius && canChase)
        {
            Shoot(player.transform.position - transform.position);
        }
        StartCoroutine(ShootCooldown());
    }

    protected IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(chaseCooldown);
        canShoot = true;
    }

}
