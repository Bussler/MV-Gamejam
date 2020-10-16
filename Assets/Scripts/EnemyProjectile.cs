using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public int damage;
    public Vector3 moveVec;

    public enum trajectory
    {
        straight,
        wiggle,
        targetSeeking,


    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(moveVec * speed * Time.deltaTime,Space.World);
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        //Test for player and do damage
        if (other.gameObject.tag != "Enemy")
        {
          
            Destroy(gameObject);
        }
    }
}
