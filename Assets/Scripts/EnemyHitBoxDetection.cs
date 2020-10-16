using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// Script which is responsible for all hitbox detections from a player with something
public class EnemyHitBoxDetection : MonoBehaviour
{
 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Honey"))
        {
            Debug.Log("Hit");
            this.GetComponent<Gegner>().TakeDamage(GameObject.FindObjectOfType<StatManager>().GetAttackDamage());


        } 



        
       
    }

    // Start is called before the first frame update
   
}
