using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float attackCooldown = 0.5f;
    float lastAttack;
    public float attackRange = 0.8f;
    public LayerMask enemyLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastAttack >= attackCooldown)
        {
            lastAttack = Time.time;
            DoAttack();
        }
    }

    void DoAttack()
    {
        var playerStats = GetComponent<PlayerStatsMono>();
        int damage = playerStats != null ? playerStats.GetAttack() : 1;

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);
        foreach (var c in hits)
        {
            var enemy = c.GetComponent<Enemy>();
            if (enemy != null) enemy.ReceiveDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

