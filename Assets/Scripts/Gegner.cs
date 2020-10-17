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
        BounceOffWall,
        CircleAroundPlayer,
        StopAndMove
    }
    public MovementType moveType;
    public float dodgeRange;
    public float timeBetweenDirectionChange;
    private float time;
    private Vector3 randomDirection;
    public float attackPerSecond;
    public enum AttackType
    {
        ShootTowardsPlayer,
        ShootRandomDirection,
        ShootSpecificDiretions,
        ShootPredicitveShot,
        ShootSpreadTowardsPlayer
    }
    public AttackType attackType;
    public Vector2[] directions;
    public int spreadAnzahl;
    public float spreadFactor;
    public GameObject projectile;

    public GameObject player;

    int x = 0;
    private Vector3 playerMoveDirection;
    private Vector3 playerLastPos;

    public GameObject DieParticle;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;

        if(moveType== MovementType.Random)
        {
            InvokeRepeating("ChangeRandomDirection",0f,timeBetweenDirectionChange);
        }
        if (moveType == MovementType.BounceOffWall)
        {
            ChangeRandomDirection();
            this.GetComponent<Rigidbody2D>().AddForce(randomDirection*10,ForceMode2D.Impulse);
        }
        InvokeRepeating("Attack", 1/ attackPerSecond ,1/ attackPerSecond);
        do
        {
            x = Random.Range(-1, 2);
        } while (x == 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerMoveDirection = player.transform.position - playerLastPos;
        playerLastPos = player.transform.position;
        switch (moveType)
        {
            case MovementType.Random:
                this.transform.Translate(randomDirection * moveSpeed * Time.deltaTime);
                break;

                case MovementType.FollowPlayer:
                this.transform.Translate((player.transform.position - this.transform.position).normalized * moveSpeed*Time.deltaTime);
                if((player.transform.position - this.transform.position).magnitude < dodgeRange)
                {
                    time += Time.deltaTime;
                   
                    if (time > timeBetweenDirectionChange)
                    {
                        do
                        {
                            x = Random.Range(-1, 2);
                        } while (x == 0);


                        time = 0;
                    }
                    Vector2 p = (player.transform.position - this.transform.position);
                    
                    this.transform.Translate(Vector2.Perpendicular(p).normalized * moveSpeed*1.5f*x * Time.deltaTime);
                }
                break;

            case MovementType.Stationary:

                break;

            case MovementType.BounceOffWall:
               // this.transform.Translate(randomDirection * moveSpeed * Time.deltaTime);
                break;
            case MovementType.CircleAroundPlayer:
               
                if ((player.transform.position - this.transform.position).magnitude < dodgeRange)
                {
                    time += Time.deltaTime;

                    if (time > timeBetweenDirectionChange)
                    {
                        do
                        {
                            x = Random.Range(-1, 2);
                        } while (x == 0);


                        time = 0;
                    }
                    Vector2 p = (player.transform.position - this.transform.position);

                    this.transform.Translate(Vector2.Perpendicular(p).normalized * moveSpeed * 1.5f * x * Time.deltaTime);
                }
                else
                {
                     this.transform.Translate((player.transform.position - this.transform.position).normalized * moveSpeed * Time.deltaTime);
                }
                break;

            case MovementType.StopAndMove:
                time += Time.deltaTime;

                if (time > timeBetweenDirectionChange)
                {


                    x = -x;
                    time = 0;
                }
                if (x < 0)
                {
                    this.transform.Translate((player.transform.position - this.transform.position).normalized * moveSpeed * Time.deltaTime);
                }
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
        Instantiate(DieParticle, this.transform.position, Quaternion.identity);
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
                //Debug.Log("attack");
                GameObject g= Instantiate(projectile, this.transform.position, Quaternion.identity);
                g.transform.right = player.transform.position - g.transform.position;
                g.GetComponent<EnemyProjectile>().moveVec = (player.transform.position - g.transform.position).normalized;
                g.GetComponent<EnemyProjectile>().enemy = this.gameObject;

                break;

            case AttackType.ShootRandomDirection:
                GameObject k = Instantiate(projectile, this.transform.position, Quaternion.identity);
                Vector3 m = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
                k.transform.right = m;
                k.GetComponent<EnemyProjectile>().moveVec = m;
                k.GetComponent<EnemyProjectile>().enemy = this.gameObject;
                break;

            case AttackType.ShootSpecificDiretions:

                for(int i=0; i < directions.Length; i++)
                {
                    GameObject p = Instantiate(projectile, this.transform.position, Quaternion.identity);
                    p.transform.right = directions[i];
                    p.GetComponent<EnemyProjectile>().moveVec = directions[i].normalized;
                    p.GetComponent<EnemyProjectile>().enemy = this.gameObject;
                }
                break;

            case AttackType.ShootPredicitveShot:
                GameObject l = Instantiate(projectile, this.transform.position, Quaternion.identity);
                l.transform.right = (player.transform.position+playerMoveDirection*3) - l.transform.position;
                l.GetComponent<EnemyProjectile>().moveVec = ((player.transform.position + playerMoveDirection*3) - l.transform.position).normalized;
                l.GetComponent<EnemyProjectile>().enemy = this.gameObject;
                break;

            case AttackType.ShootSpreadTowardsPlayer:

                float x;
                //if (SpreadAnzahl % 2 == 0)
               // {
                    x = (spreadAnzahl-1) / 2f;
                //}


                for (int i = 0; i < spreadAnzahl; i++)
                {
                    GameObject p = Instantiate(projectile, this.transform.position, Quaternion.identity);
                    if (p != null)
                    {
                        p.transform.right = (new Vector2(player.transform.position.x, player.transform.position.y) + Vector2.Perpendicular(new Vector2((player.transform.position - this.transform.position).x, (player.transform.position - this.transform.position).y)) * x * spreadFactor - Vector2.Perpendicular(new Vector2((player.transform.position - this.transform.position).x, (player.transform.position - this.transform.position).y)) * i * spreadFactor) - new Vector2(this.transform.position.x, this.transform.position.y);
                        p.GetComponent<EnemyProjectile>().moveVec = p.transform.right.normalized;
                        p.GetComponent<EnemyProjectile>().enemy = this.gameObject;
                    }
                }
                break;

        }


    }

  
}
