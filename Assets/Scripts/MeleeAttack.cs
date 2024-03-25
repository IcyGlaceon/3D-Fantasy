using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public GameObject Weapon;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;
    public bool IsAttacking = false;

    // Audio Sources
    public AudioClip AttackSound;

    void Update()
    {
        if (Input.GetMouseButton(0) && CanAttack)
        {
            Attack();
        }
    }

    public void Attack()
    {
        IsAttacking = true;
        CanAttack = false;
        Animator anim = Weapon.GetComponent<Animator>();

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
