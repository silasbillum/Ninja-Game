using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float attackRange = 2f; // The distance at which the enemy starts attacking
    public float attackCooldown = 1f; // The time between each attack
    public Transform attackPoint; // The position from where the attack is initiated
    public float attackRadius = 0.5f; // The radius of the attack range
    public float attackAnimationDuration = 1f; // The duration of the attack animation
    public float attackDamage = 20f;

    private Animator animator;
    private bool isAttacking = false;
    private float attackTimer = 0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isAttacking)
        {
            // Calculate the distance between the enemy and the player
            float distanceToPlayer = Vector2.Distance(transform.position, CharacterController2D.Instance.transform.position);

            // Check if the player is within the attack range
            if (distanceToPlayer <= attackRange)
            {
                // Start attacking
                Attack();
            }
        }
        else
        {
            // Count down the attack timer
            attackTimer -= Time.deltaTime;

            // Check if the attack cooldown is over
            if (attackTimer <= 0f)
            {
                // Stop attacking
                StopAttack();
            }
        }
    }

    private void Attack()
    {
        // Start the attack animation
        animator.SetTrigger("Attack");

        // Set the attack timer to the duration of the attack animation
        attackTimer = attackAnimationDuration;

        // Set the enemy to attacking state
        isAttacking = true;
    }

    private void StopAttack()
    {
        // Reset the attack timer
        attackTimer = 0f;

        // Set the enemy to not attacking state
        isAttacking = false;
    }

    // Called by the attack animation event
    private void PerformAttack()
    {
        // Check if the player is within the attack range
        float distanceToPlayer = Vector2.Distance(transform.position, CharacterController2D.Instance.transform.position);
        if (distanceToPlayer <= attackRange)
        {
            // Check if the player is within the attack radius
            if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= attackRadius)
            {
                // Define the damage amount to be inflicted on the player
                int damageAmount = 100; // Replace with the desired damage amount

                // Attack the player
                GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>().TakeDamage(damageAmount);
            }


        }
    }
}
