using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StatManager : MonoBehaviour
{
    public static StatManager StatManagerInstance { get; private set; }
    // Start is called before the first frame update

    //[SerializeField] private int playerSpeed = 5, lifePoints = 100, attackRange = 10, attackDamage = 1, numberOfDashes = 1, dashCooldownInSeconds = 20, projectileSpeed = 5;
    //Reihenfolge der attribute wie in der Zeile hierüber
    [SerializeField]
    private int[] playerAttributes = new[]
    {
        5,
        100,
        10,
        1,
        1,
        20,
        5
    };
    
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
    }
    public int GetLifePoints()
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
    public int GetPlayerSpeed()
    {
        return playerAttributes[0];
    }

    public void IncreaseAttackRange(int increase)
    {
        playerAttributes[2] += increase;
    }
    public void DecreaseAttackRange(int decrease)
    {
        playerAttributes[2] -= decrease;
    }
    public int GetAttackRange()
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
    public int GetAttackDamage()
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
    public int GetNumberOfDashes()
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
    public int GetDashCooldown()
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
    public int GetProjectileSpeed()
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