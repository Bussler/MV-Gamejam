using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public int damage;
    public Vector3 moveVec;

    public enum Trajectory
    {
        straight,
        wiggle,
        targetSeeking,
        orbiting,
        piercing,
        bouncing,
        


    }

    public Trajectory trajectoryType;
    private GameObject player;
    public GameObject enemy;
    private float time;
    private int x=1;

    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
        if (trajectoryType==Trajectory.orbiting)
        {

            this.transform.position += moveVec * 2;

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (trajectoryType)
        {

            case Trajectory.straight:
                this.transform.Translate(moveVec * speed * Time.deltaTime, Space.World);
                break;

            case Trajectory.wiggle:
                this.transform.Translate(moveVec * speed * 1f * Time.deltaTime, Space.World);
               
                    time += Time.deltaTime;

                    if (time > 0.33f)
                    {
                         x = -x;


                        time = 0;
                    }
                    Vector2 p = (player.transform.position - this.transform.position);

                    this.transform.Translate(Vector2.Perpendicular(p).normalized * speed * 0.5f * x * Time.deltaTime);
               
                break;

            case Trajectory.targetSeeking:
                this.transform.Translate(moveVec * speed* 0.3f * Time.deltaTime, Space.World);
                this.transform.Translate((player.transform.position-this.transform.position).normalized *0.7f *speed * Time.deltaTime, Space.World);

                break;
            case Trajectory.orbiting:
                if (enemy != null)
                {
                    this.transform.Translate(Vector2.Perpendicular((enemy.transform.position - this.transform.position)).normalized * speed * 2f * Time.deltaTime, Space.World);

                    this.transform.Translate((enemy.transform.position - this.transform.position).normalized * -speed * 0.01f * Time.deltaTime, Space.World);
                }
                break;
            case Trajectory.piercing:
                this.transform.Translate(moveVec * speed * Time.deltaTime, Space.World);
                break;
          
            case Trajectory.bouncing:
                this.transform.Translate(moveVec * speed * Time.deltaTime, Space.World);
                break;
        }


        
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        //Test for player and do damage
        if (other.gameObject.tag != "Enemy" &&other.gameObject.tag!="Honey")
        {
            if (trajectoryType == Trajectory.bouncing&& other.tag != "EnemyProjectile" )
            {
                int l = 0;
                Debug.Log(Vector3.SignedAngle(moveVec, other.ClosestPoint(this.transform.position) - new Vector2(this.transform.position.x, this.transform.position.y),Vector3.back));
                if(Vector3.SignedAngle(moveVec, other.ClosestPoint(this.transform.position) - new Vector2(this.transform.position.x, this.transform.position.y), Vector3.back) > 0)
                {
                    l = 1;
                }
                else
                {
                    l = -1;
                }
               
                moveVec = Vector2.Perpendicular(moveVec)*l;
            }
            
            if (trajectoryType != Trajectory.piercing&& trajectoryType != Trajectory.bouncing && other.tag != "EnemyProjectile")
            {
                Instantiate(particle, this.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            
        }
    }
}
