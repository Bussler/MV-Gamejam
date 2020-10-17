using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyMovement : MonoBehaviour
{
    private float lifeTime = StatManager.StatManagerInstance.GetProjectileLifetime();

    public Vector2 mvtVec;
    

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
