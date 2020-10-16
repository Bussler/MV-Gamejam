using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gegner : MonoBehaviour
{

    public int health;
    public float moveSpeed;
    public enum MovementType
    {
        Random,
        FollowPlayer,
        Stationary,
        BounceOffWall
    }
    public MovementType moveType;
    public float timeBetweenDirectionChange;
    private Vector3 randomDirection;
    public float attackPerSecond;
    public enum AttackType
    {
        ShootTowardsPlayer,
        ShootRandomDirection,
        ShootSpecificDiretions
    }
    public AttackType attackType;
    public Vector2[] directions;
    public GameObject projectile;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if(moveType== MovementType.Random)
        {
            InvokeRepeating("ChangeRandomDirection",0f,timeBetweenDirectionChange);
        }
        InvokeRepeating("Attack", 1/ attackPerSecond ,1/ attackPerSecond);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (moveType)
        {
            case MovementType.Random:
                this.transform.Translate(randomDirection * moveSpeed * Time.deltaTime);
                break;

                case MovementType.FollowPlayer:
                this.transform.Translate((player.transform.position - this.transform.position).normalized * moveSpeed*Time.deltaTime);
                break;

            case MovementType.Stationary:

                break;

            case MovementType.BounceOffWall:

                break;
        }




    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

    public void ChangeRandomDirection()
    {
        randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
    }

    public void Attack() {

        switch (attackType)
        {
            case AttackType.ShootTowardsPlayer:
               GameObject g= Instantiate(projectile, this.transform.position, Quaternion.identity);
                g.transform.right = player.transform.position - g.transform.position;
                g.GetComponent<EnemyProjectile>().moveVec = (player.transform.position - g.transform.position).normalized;


                break;

            case AttackType.ShootRandomDirection:
                GameObject k = Instantiate(projectile, this.transform.position, Quaternion.identity);
                Vector3 m = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
                k.transform.right = m;
                k.GetComponent<EnemyProjectile>().moveVec = m;
                break;

            case AttackType.ShootSpecificDiretions:

                for(int i=0; i < directions.Length; i++)
                {
                    GameObject p = Instantiate(projectile, this.transform.position, Quaternion.identity);
                    p.transform.right = directions[i];
                    p.GetComponent<EnemyProjectile>().moveVec = directions[i].normalized;
                }
                break;

           
        }


    }
}
