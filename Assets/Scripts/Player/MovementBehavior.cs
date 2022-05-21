using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 3;

    private new Rigidbody2D rigidbody;
    private Animator animator;
    private new SpriteRenderer renderer;
    private bool isMoving;
    private float increaseMovementSpeedModifier;
    private bool dead = false;
    private Dictionary<string, float> increaseMsModifiers;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        increaseMovementSpeedModifier = 1f;
        increaseMsModifiers = new Dictionary<string, float>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!dead)
        {
            MoveCharacter();
        }
    }

    void MoveCharacter()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        isMoving = !(direction == Vector2.zero);
        animator.SetBool("IsMoving", isMoving);
        renderer.flipX = direction.x < 0;
        direction.Normalize();
        direction *= movementSpeed * increaseMovementSpeedModifier;
        rigidbody.transform.Translate(direction * Time.fixedDeltaTime);
    }

    public void AddMovementSpeedModifier(string source, float value)
    {
        increaseMsModifiers.Add(source, value);
        increaseMovementSpeedModifier += value;
    }

    public void RemoveMovementSpeedModifier(string source)
    {
        if (increaseMsModifiers.ContainsKey(source))
        {
            increaseMovementSpeedModifier -= increaseMsModifiers[source];
            increaseMsModifiers.Remove(source);
        }
    }

    public void Dead()
    {
        dead = true;
        isMoving = false;
        animator.SetBool("IsMoving", false);
    }

    public bool IsMoving { get { return isMoving; } }
}
