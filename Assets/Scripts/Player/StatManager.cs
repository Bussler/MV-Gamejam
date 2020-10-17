﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StatManager : MonoBehaviour
{
    public static StatManager StatManagerInstance { get; private set; }
    // Start is called before the first frame update

    //[SerializeField] private int playerSpeed = 5, lifePoints = 100, attackRange = 10, attackDamage = 1, numberOfDashes = 1, dashCooldownInSeconds = 20, projectileSpeed = 5, fireRate;
    //Reihenfolge der attribute wie in der Zeile hierüber
    [SerializeField]
    private float[] playerAttributes = new []
    {
        5.0f,     // playerSpeed
        100.0f,   // lifePoints
        0.7f,     // projectileLifetime
        1.0f,     // attackDamage
        1.0f,     // numberOfDashes
        2.0f,    // dashCooldownInSeconds
        6.0f,     // projectileSpeed
        0.3f,      // fireRate
        100.0f,   // maxHealth
    };

    // poll types: -1 - none, 0 - blue, 1 - red, 2 - lila, 3 - yellow
    private bool[] hasPollen = new bool[4];
   
        private int nectarAmount = 0;
    
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
        if (playerAttributes[1] < 0)
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
        playerAttributes[1] -= damage;
        CheckIfDead();
        // TODO etwas machen
    }
    public void IncreaseLifePoints(int increase)
    {
        
        playerAttributes[1] += increase;
        if (playerAttributes[1] > playerAttributes[8])
        {
            // life points cannot be higher than max health
            playerAttributes[1] = playerAttributes[8];
        }
    }
    public float GetLifePoints()
    {
        return playerAttributes[1];
    }

    public void IncreasePlayerSpeed(int increase)
    {
        playerAttributes[0] += increase;
    }
    public void DecreasePlayerSpeed(int decrease)
    {
        playerAttributes[0] -= decrease;
    }
    public float GetPlayerSpeed()
    {
        return playerAttributes[0];
    }

    public void IncreaseProjectileLifetime(int increase)
    {
        playerAttributes[2] += increase;
    }
    public void DecreaseProjectileLifetime(int decrease)
    {
        playerAttributes[2] -= decrease;
    }
    public float GetProjectileLifetime()
    {
        return playerAttributes[2];
    }

    public void IncreaseAttackDamage(int increase)
    {
        playerAttributes[3] += increase;
    }
    public void DecreaseAttackDamage(int decrease)
    {
        playerAttributes[3] -= decrease;
    }
    public float GetAttackDamage()
    {
        return playerAttributes[3];
    }
    
    public void IncreaseNumberOfDashes(int increase)
    {
        playerAttributes[4] += increase;
    }
    public void DecreaseNumberOfDashes(int decrease)
    {
        playerAttributes[4] -= decrease;
    }
    public float GetNumberOfDashes()
    {
        return playerAttributes[4];
    }
    
    public void IncreaseDashCooldown(int increase)
    {
        playerAttributes[5] += increase;
    }
    public void DecreaseDashCooldown(int decrease)
    {
        playerAttributes[5] -= decrease;
    }
    public float GetDashCooldown()
    {
        return playerAttributes[5];
    }
    
    public void IncreaseProjectileSpeed(int increase)
    {
        playerAttributes[6] += increase;
    }
    public void DecreaseProjectileSpeed(int decrease)
    {
        playerAttributes[6] -= decrease;
    }
    public float GetProjectileSpeed()
    {
        return playerAttributes[6];
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
    
    public void IncreaseFireRate(int increase)
    {
        playerAttributes[7] += increase;
    }
    public void DecreaseFireRate(int decrease)
    {
        playerAttributes[7] -= decrease;
    }
    public float GetFireRate()
    {
        return playerAttributes[7];
    }
    
    public void IncreaseMaxHealth(int increase)
    {
        playerAttributes[8] += increase;
    }
    public void DecreaseMaxHealth(int decrease)
    {
        playerAttributes[8] -= decrease;
    }
    public float GetMaxHealth()
    {
        return playerAttributes[8];
    }

    public void SetCurrentPollType(int type){}

    public void AddCurrentPollType(int type, int amount)
    {
        if (hasPollen[type])
        {
            IncreaseNectarAmount(amount);
            // currentPollType =
        }
        else
        {
            // TODO ändert sich das dann sofort wenn man zu einem anderen geht?
            //currentPollType = type;
        }
    }
    
}