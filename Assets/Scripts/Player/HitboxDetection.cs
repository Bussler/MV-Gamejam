using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// Script which is responsible for all hitbox detections from a player with something
public class HitboxDetection : MonoBehaviour
{
    private BoxCollider2D _playerHitbox;
    
    private String _playerTag = "Player";

    [SerializeField] private int rosesDamage = 10;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Roses"))
        {
            StatManager.StatManagerInstance.DecreaseLifePoints(rosesDamage);
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("EnemyProjectile"))
        {
            Debug.Log("HIT " + other.gameObject.GetComponent<EnemyProjectile>().damage);
            int damage = other.gameObject.GetComponent<EnemyProjectile>().damage;
            StatManager.StatManagerInstance.DecreaseLifePoints(damage);
            return;
        }
        
        // flower tags are built like this: Flower-1 / Flower-2 .....
        String[] objectTags = other.gameObject.tag.Split('-');
        if (objectTags[0].Equals("Flower"))
        {
            int flowerType = int.Parse(objectTags[1]);
            StatManager.StatManagerInstance.SetCurrentPollType(flowerType);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerHitbox = gameObject.GetComponent<BoxCollider2D>();
    }
}
