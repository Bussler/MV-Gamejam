using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public int damage;
    public Vector3 moveVec;
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


    public void OnTriggerEnter(Collider other)
    {
        //Test for player and do damage
        Destroy(gameObject);
    }
}
