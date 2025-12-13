using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHP = 30;
    int currentHP;
    public int attack = 5;
    public int xpDrop = 30;

    void Awake()
    {
        currentHP = maxHP;
    }

    public void ReceiveDamage(int dmg)
    {
        currentHP -= Mathf.Max(0, dmg);
        if (currentHP <= 0) Die();
    }

    void Die()
    {
        // Drop XP to player directly (simple)
        var playerStats = FindFirstObjectByType<PlayerStatsMono>();
        if (playerStats != null) playerStats.AddXP(xpDrop);
        Destroy(gameObject);
    }
}
