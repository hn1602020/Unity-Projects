using UnityEngine;

public class PlayerStatsMono : MonoBehaviour
{
    public Stats stats = new Stats();

    public void AddXP(int amount)
    {
        stats.GainXP(amount);
        // Could notify UI here
    }

    public int GetAttack()
    {
        return stats.attack + EquipmentManager.Instance.GetTotalAttackBonus();
    }

    public int GetDefense()
    {
        return stats.defense + EquipmentManager.Instance.GetTotalDefenseBonus();
    }
}
