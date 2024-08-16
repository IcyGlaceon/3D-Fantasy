using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class RangeAttack : MonoBehaviour
{
    [SerializeField] GameObject Weapon;
    [SerializeField] GameObject Projectile;
    [SerializeField] Transform SpawnPosition;
    [SerializeField] Transform TargetPOS;

    private bool CanAttack = true;
    private float AttackCooldown = 1.0f;
    [HideInInspector] public bool IsAttacking = false;

    private RaycastHit targetHit = new RaycastHit();
    Vector3 box = new Vector3(5f, 5f, 5f);
    Vector3 baseTarget;

    private PlayerInput playerInput;

    // Audio Sources
    public AudioClip AttackSound;

    private void Start()
    {
        playerInput = GetComponentInParent<PlayerInput>();
        baseTarget = TargetPOS.localPosition;
    }

    void Update()
    {
        if (playerInput.actions["Fire"].IsPressed() && CanAttack)
        {
            Attack();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(TargetPOS.position, box * 2);
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
        //Targetting testing
        Physics.BoxCast(TargetPOS.position, box * 2, transform.forward, out targetHit);
        if (targetHit.collider && (targetHit.collider.CompareTag("Breakable") || targetHit.collider.CompareTag("Breakable")))
        {
            TargetPOS.position = targetHit.transform.position;
            Debug.Log("It hit: " + targetHit.collider.gameObject.name);
            
        }
        //testing ends
        
        Vector3 dir = TargetPOS.position - SpawnPosition.position;

        GameObject projectile = Instantiate(Projectile, SpawnPosition.position, Quaternion.identity);

        projectile.transform.forward = dir.normalized;

        projectile.GetComponent<Rigidbody>().AddForce(dir.normalized * 10, ForceMode.Impulse);
        projectile.GetComponent<CollisionDetectionRange>().ra = this;
        TargetPOS.localPosition = baseTarget;
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
        IsAttacking = false;
    }
}
