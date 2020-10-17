using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public enum stats
    {
        PlayerSpeed,
        LifePoints,
        ProjectileLifeTime,
        AttackDamage,
        NumberOfDashes,
        DashCooldown,
        ProjectileSpeed,
        FireRate,
        MaxHealth,
        MaxNumOfDashes
    }
    public new String name;
    public int cost;
    public Sprite image;
    public stats[] changedStats;
    public float[] changedStatsAmount;
    public bool[] isPositiveBonus;

    public void ApplyEffects()
    {
        for (int i = 0; i < changedStats.Length; i++)
        {
            switch (changedStats[i])
            { 
                case stats.PlayerSpeed:
                    if (isPositiveBonus[i])
                        StatManager.StatManagerInstance.IncreasePlayerSpeed(changedStatsAmount[i]);
                    else
                        StatManager.StatManagerInstance.DecreasePlayerSpeed(changedStatsAmount[i]);
                    break;
                case stats.LifePoints:
                    if(isPositiveBonus[i])
                        StatManager.StatManagerInstance.IncreaseLifePoints(changedStatsAmount[i]);
                    else
                        StatManager.StatManagerInstance.DecreaseLifePoints(changedStatsAmount[i]);
                    break;
                case stats.ProjectileLifeTime:
                    if(isPositiveBonus[i])
                        StatManager.StatManagerInstance.IncreaseProjectileLifetime(changedStatsAmount[i]);
                    else
                        StatManager.StatManagerInstance.DecreaseProjectileLifetime(changedStatsAmount[i]);
                    break;
                case stats.AttackDamage: 
                    if(isPositiveBonus[i])
                        StatManager.StatManagerInstance.IncreaseAttackDamage(changedStatsAmount[i]);
                    else
                        StatManager.StatManagerInstance.DecreaseAttackDamage(changedStatsAmount[i]);
                    break;
                case stats.NumberOfDashes: 
                    if(isPositiveBonus[i])
                        StatManager.StatManagerInstance.IncreaseNumberOfDashes(changedStatsAmount[i]);
                    else
                        StatManager.StatManagerInstance.DecreaseNumberOfDashes(changedStatsAmount[i]);
                    break;
                case stats.DashCooldown:
                    if(isPositiveBonus[i])
                        StatManager.StatManagerInstance.DecreaseDashCooldown(changedStatsAmount[i]);
                    else
                        StatManager.StatManagerInstance.IncreaseDashCooldown(changedStatsAmount[i]);
                    break;
                case stats.ProjectileSpeed:
                    if(isPositiveBonus[i])
                        StatManager.StatManagerInstance.IncreaseProjectileSpeed(changedStatsAmount[i]);
                    else
                        StatManager.StatManagerInstance.DecreasePlayerSpeed(changedStatsAmount[i]);
                    break;
                case stats.FireRate:
                    if(isPositiveBonus[i])
                        StatManager.StatManagerInstance.IncreaseFireRate(changedStatsAmount[i]);
                    else
                        StatManager.StatManagerInstance.DecreaseFireRate(changedStatsAmount[i]);
                    break;
                case stats.MaxHealth:
                    if (isPositiveBonus[i])
                    {
                        StatManager.StatManagerInstance.IncreaseMaxHealth(changedStatsAmount[i]);
                        StatManager.StatManagerInstance.IncreaseLifePoints(changedStatsAmount[i]);
                    }
                    else
                    {
                        StatManager.StatManagerInstance.DecreaseMaxHealth(changedStatsAmount[i]);
                        StatManager.StatManagerInstance.DecreaseLifePoints(changedStatsAmount[i]);
                    }
                    break;
                case stats.MaxNumOfDashes:
                    if (isPositiveBonus[i])
                        StatManager.StatManagerInstance.IncreaseMaxNumberOfDashes(changedStatsAmount[i]);
                    else
                        StatManager.StatManagerInstance.DecreaseMaxNumberOfDashes(changedStatsAmount[i]);
                    break;
            }
        }
    }
}