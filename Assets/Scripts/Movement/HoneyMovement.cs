using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyMovement : MonoBehaviour
{
    public float projectileSpeed = 6;
    public float lifeTime = 0.8f;

    public Vector2 mvtVec;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (mvtVec == null)
            return;

        float amtToMove = projectileSpeed * Time.deltaTime;

        transform.Translate(mvtVec * amtToMove, Space.World);

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Roses")
            Destroy(gameObject);
    }

}
