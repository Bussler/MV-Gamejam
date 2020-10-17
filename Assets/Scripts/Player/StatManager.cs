using System;
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
        3f,   // lifePoints
        0.7f,     // projectileLifetime
        1.0f,     // attackDamage
        2.0f,     // numberOfDashes
        2.0f,    // dashCooldownInSeconds
        6.0f,     // projectileSpeed
        0.3f,      // fireRate
        6f,   // maxHealth
        2.0f    //maxNumOfDashes
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
    
    public void DecreaseLifePoints(float damage)
    {
        playerAttributes[1] -= damage;
        CheckIfDead();
        // TODO etwas machen
    }
    public void IncreaseLifePoints(float increase)
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

    public void IncreasePlayerSpeed(float increase)
    {
        playerAttributes[0] += increase;
    }
    public void DecreasePlayerSpeed(float decrease)
    {
        playerAttributes[0] -= decrease;
    }
    public float GetPlayerSpeed()
    {
        return playerAttributes[0];
    }

    public void IncreaseProjectileLifetime(float increase)
    {
        playerAttributes[2] += increase;
    }
    public void DecreaseProjectileLifetime(float decrease)
    {
        playerAttributes[2] -= decrease;
    }
    public float GetProjectileLifetime()
    {
        return playerAttributes[2];
    }

    public void IncreaseAttackDamage(float increase)
    {
        playerAttributes[3] += increase;
    }
    public void DecreaseAttackDamage(float decrease)
    {
        playerAttributes[3] -= decrease;
    }
    public float GetAttackDamage()
    {
        return playerAttributes[3];
    }
    
    public void IncreaseNumberOfDashes(float increase)
    {
        playerAttributes[4] += increase;
    }
    public void DecreaseNumberOfDashes(float decrease)
    {
        playerAttributes[4] -= decrease;
    }
    public float GetNumberOfDashes()
    {
        return playerAttributes[4];
    }

    public void IncreaseMaxNumberOfDashes(float increase)
    {
        playerAttributes[9] += increase;
    }
    public void DecreaseMaxNumberOfDashes(float decrease)
    {
        playerAttributes[9] -= decrease;
    }
    public float GetMaxNumberOfDashes()
    {
        return playerAttributes[9];
    }

    public void IncreaseDashCooldown(float increase)
    {
        playerAttributes[5] += increase;
    }
    public void DecreaseDashCooldown(float decrease)
    {
        playerAttributes[5] -= decrease;
    }
    public float GetDashCooldown()
    {
        return playerAttributes[5];
    }
    
    public void IncreaseProjectileSpeed(float increase)
    {
        playerAttributes[6] += increase;
    }
    public void DecreaseProjectileSpeed(float decrease)
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
    
    public void IncreaseFireRate(float increase)
    {
        playerAttributes[7] += increase;
    }
    public void DecreaseFireRate(float decrease)
    {
        playerAttributes[7] -= decrease;
    }
    public float GetFireRate()
    {
        return playerAttributes[7];
    }
    
    public void IncreaseMaxHealth(float increase)
    {
        playerAttributes[8] += increase;
    }
    public void DecreaseMaxHealth(float decrease)
    {
        playerAttributes[8] -= decrease;
    }
    public float GetMaxHealth()
    {
        return playerAttributes[8];
    }

    

    public void AddPollType(int type, int amount)
    {
        if (hasPollen[type])
        {
            IncreaseNectarAmount(amount*2);
            // currentPollType =
            GameObject.FindObjectOfType<PlayerMovement>().transform.GetChild(1).GetChild(type).gameObject.SetActive(false);
            hasPollen[type] = false;
            playerAttributes[0] += 0.25f;
        }
        else
        {
            hasPollen[type] = true;
            IncreaseNectarAmount(amount * 1);
            GameObject.FindObjectOfType<PlayerMovement>().transform.GetChild(1).GetChild(type).gameObject.SetActive(true);
            // TODO ändert sich das dann sofort wenn man zu einem anderen geht?
            //currentPollType = type;
            playerAttributes[0] -= 0.25f;
        }
    }
    
}