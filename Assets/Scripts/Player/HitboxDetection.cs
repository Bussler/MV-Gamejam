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

    public bool blinking = false;

    [SerializeField] private int rosesDamage = 1;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Roses") && !blinking)
        {
            StatManager.StatManagerInstance.DecreaseLifePoints(rosesDamage);
            StartCoroutine(DoBlinks(3, 0.2f));//corotine zum blinken
            blinking = true;
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("EnemyProjectile") && !blinking)
        {
            Debug.Log("HIT " + other.gameObject.GetComponent<EnemyProjectile>().damage);
            int damage = other.gameObject.GetComponent<EnemyProjectile>().damage;
            StatManager.StatManagerInstance.DecreaseLifePoints(damage);
            StartCoroutine(DoBlinks(3, 0.2f));//corotine zum blinken
            blinking = true;
            return;
        }
        
        // flower tags are built like this: Flower-1 / Flower-2 .....
        String[] objectTags = other.gameObject.tag.Split('-');
        if (objectTags[0].Equals("Flower"))
        {
            int flowerType = int.Parse(objectTags[1]);
           // StatManager.StatManagerInstance.SetCurrentPollType(flowerType);
        }
    }

    IEnumerator DoBlinks(int blinks, float blinkTime)
    {
        bool half = false;
        Color cur = GetComponent<SpriteRenderer>().color;

        for (int i=0; i<blinks*2; i++)
        {
            if (half)
            {
                this.GetComponent<SpriteRenderer>().color = new Color(cur.r, cur.g, cur.b, 1);
                half = false;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = new Color(cur.r, cur.g, cur.b, 0.3f);
                half = true;
            }
            //wait for a bit
            yield return new WaitForSeconds(blinkTime);
        }

        //make sure renderer is setup when we exit
        this.GetComponent<SpriteRenderer>().color = new Color(cur.r, cur.g, cur.b, 1);
        blinking = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerHitbox = gameObject.GetComponent<BoxCollider2D>();
    }
}
