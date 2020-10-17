using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyMovement : MonoBehaviour
{
    private float lifeTime = 0.7f;// StatManager.StatManagerInstance.GetProjectileLifetime();

    public Vector2 mvtVec;

    private void Start()
    {
        lifeTime = StatManager.StatManagerInstance.GetProjectileLifetime();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (mvtVec == null)
            return;

        float amtToMove = StatManager.StatManagerInstance.GetProjectileSpeed() * Time.deltaTime;

        transform.Translate(mvtVec * amtToMove, Space.World);

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Wall") || collision.gameObject.tag.Equals("Roses"))
            Destroy(gameObject);
    }

}
