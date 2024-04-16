using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RangeAttack : MonoBehaviour
{
    [SerializeField] GameObject Weapon;
    [SerializeField] GameObject Projectile;
    [SerializeField] Transform SpawnPosition;
    [SerializeField] Transform TargetPOS;

    private bool CanAttack = true;
    private float AttackCooldown = 1.0f;
    [HideInInspector] public bool IsAttacking = false;

    private PlayerInput playerInput;

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
        Animator anim = Weapon.GetComponent<Animator>();

        anim.SetTrigger("Attack");

        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(AttackSound);

        StartCoroutine(ResetAttackCooldown());
    }

    public void SpawnProjectile()
    {
        Vector3 dir = TargetPOS.position - SpawnPosition.position;

        GameObject projectile = Instantiate(Projectile, SpawnPosition.position, Quaternion.identity);

        projectile.transform.forward = dir.normalized;

        projectile.GetComponent<Rigidbody>().AddForce(dir.normalized * 10, ForceMode.Impulse);
        projectile.GetComponent<CollisionDetectionRange>().ra = this;
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
        IsAttacking = false;
    }
}
