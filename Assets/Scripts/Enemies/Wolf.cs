using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : BasicEnemy
{
    [SerializeField]
    private float howlDelay = 20f;
    private float howlDuration = 5f;
    private bool canHowl = true;

    private Animator animator;
    private AudioSource howlAudio;
    private AudioSource biteAudio;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        foreach (AudioSource source in gameObject.GetComponents<AudioSource>())
        {
            if (source.clip.name == "wolf_-_long_howl")
            {
                howlAudio = source;
            }
            else if (source.clip.name == "кусьзапопу")
            {
                biteAudio = source;
            }
        }
        howlDuration = howlAudio.clip.length;
    }

    private void Update()
    {
        animator.SetBool("isRunning", canChase && Vector2.Distance(transform.position, player.transform.position) <= aggroRadius);
        if (!animator.GetBool("isRunning") && canHowl)
        {
            StartCoroutine(HowlDelay());
        }
    }

    protected override void ChasePlayer()
    {
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
        direction *= movementSpeed;
        rigidbody.transform.Translate(direction * Time.fixedDeltaTime);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.tag == "Player")
        {
            biteAudio.Play();
        }
    }

    private IEnumerator HowlDelay()
    {
        canHowl = false;
        yield return new WaitForSeconds(howlDelay);

        animator.SetTrigger("Howl");
        howlAudio.Play();
        
        yield return new WaitForSeconds(howlDuration);
        canHowl = true;
    }
}
