using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleeAttack : MonoBehaviour
{
    public GameObject Weapon;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;
    public bool IsAttacking = false;

    private PlayerInput playerInput;

    public Animator anim;

    // Audio Sources
    public AudioClip AttackSound;

    private void Start()
    {
        playerInput = GetComponentInParent<PlayerInput>();
    }

    void Update()
    {
        if (playerInput.actions["Fire"].IsPressed() && CanAttack)
        {
            Attack();
        }
    }

    public void Attack()
    {
        IsAttacking = true;
        CanAttack = false;
        
        anim.SetTrigger("Attack");

        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(AttackSound);

        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
        IsAttacking = false;
    }
}
