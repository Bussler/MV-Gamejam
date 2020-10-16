using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public new String name;
    public int cost;
    public int[] changedStats;
    public int[] changedStatsAmount;

    public void ApplyEffects()
    {
        for (int i = 0; i < changedStats.Length; i++)
        {
            switch (changedStats[i])
            {
                case 0:
                    StatManager.StatManagerInstance.IncreasePlayerSpeed(changedStatsAmount[i]);
                    break;
                case 1:
                    StatManager.StatManagerInstance.IncreaseLifePoints(changedStatsAmount[i]);
                    break;
                case 2:
                    StatManager.StatManagerInstance.IncreaseAttackRange(changedStatsAmount[i]);
                    break;
                case 3: 
                    StatManager.StatManagerInstance.IncreaseAttackDamage(changedStatsAmount[i]);
                    break;
                case 4: 
                    StatManager.StatManagerInstance.IncreaseNumberOfDashes(changedStatsAmount[i]);
                    break;
                case 5:
                    StatManager.StatManagerInstance.DecreaseDashCooldown(changedStatsAmount[i]);
                    break;
                case 6:
                    StatManager.StatManagerInstance.IncreaseProjectileSpeed(changedStatsAmount[i]);
                    break;
            }
        }
    }
}