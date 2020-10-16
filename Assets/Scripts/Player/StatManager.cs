using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StatManager : MonoBehaviour
{
    public static StatManager StatManagerInstance { get; private set; }
    // Start is called before the first frame update

    [SerializeField] private int playerSpeed = 5, lifePoints = 100, attackRange = 10, attackDamage = 1, numberOfDashes = 1, dashCooldownInSeconds = 20, projectileSpeed = 5;

    // poll types: -1 - none, 0 - blue, 1 - red, 2 - lila, 3 - yellow
    private int currentPollType = -1, nectarAmount = 0;
    
    private bool _isDead = false;

    private void Awake()
    {
        if (StatManagerInstance == null)
        {
            StatManagerInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (StatManagerInstance != this)
        {
            Destroy(StatManagerInstance);
        }
    }

    public bool IsDead()
    {
        return _isDead;
    }
    
    private bool CheckIfDead()
    {
        if (lifePoints < 0)
        {
            _isDead = true;
            return true;
        }
        else
        {
            return false;
        }
        
    }
    
    public void DecreaseLifePoints(int damage)
    {
        lifePoints -= damage;
        CheckIfDead();
        // TODO etwas machen
    }
    public void IncreaseLifePoints(int increase)
    {
        lifePoints += increase;
    }
    public int GetLifePoints()
    {
        return lifePoints;
    }

    public void IncreasePlayerSpeed(int increase)
    {
        playerSpeed += increase;
    }
    public void DecreasePlayerSpeed(int decrease)
    {
        playerSpeed -= decrease;
    }
    public int GetPlayerSpeed()
    {
        return playerSpeed;
    }

    public void IncreaseAttackRange(int increase)
    {
        attackRange += increase;
    }
    public void DecreaseAttackRange(int decrease)
    {
        attackRange -= decrease;
    }
    public int GetAttackRange()
    {
        return attackRange;
    }

    public void IncreaseAttackDamage(int increase)
    {
        attackDamage += increase;
    }
    public void DecreaseAttackDamage(int decrease)
    {
        attackDamage -= decrease;
    }
    public int GetAttackDamage()
    {
        return attackDamage;
    }
    
    public void IncreaseNumberOfDashes(int increase)
    {
        numberOfDashes += increase;
    }
    public void DecreaseNumberOfDashes(int decrease)
    {
        numberOfDashes -= decrease;
    }
    public int GetNumberOfDashes()
    {
        return numberOfDashes;
    }
    
    public void IncreaseDashCooldown(int increase)
    {
        dashCooldownInSeconds += increase;
    }
    public void DecreaseDashCooldown(int decrease)
    {
        dashCooldownInSeconds -= decrease;
    }
    public int GetDashCooldown()
    {
        return dashCooldownInSeconds;
    }
    
    public void IncreaseProjectileSpeed(int increase)
    {
        projectileSpeed += increase;
    }
    public void DecreaseProjectileSpeed(int decrease)
    {
        projectileSpeed -= decrease;
    }
    public int GetProjectileSpeed()
    {
        return projectileSpeed;
    }

    public void IncreaseNectarAmount(int increase)
    {
        nectarAmount += increase;
    }
    public void DecreaseNectarAmount(int decrease)
    {
        nectarAmount -= decrease;
    }
    public int GetNectarAmount()
    {
        return nectarAmount;
    }
    
    public void SetCurrentPollType(int type)
    {
        if (type == currentPollType)
        {
            IncreaseNectarAmount(1);
            currentPollType = -1;
        }
        else
        {
            // TODO ändert sich das dann sofort wenn man zu einem anderen geht?
            currentPollType = type;
        }
    }
    public int GetCurrentPollType()
    {
        return currentPollType;
    }
}