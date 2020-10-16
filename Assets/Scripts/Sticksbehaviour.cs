using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticksbehaviour : MonoBehaviour
{
    public int lives = 5;
    [SerializeField]
    float minusAlpha = 0.15f;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Honey")
        {
            Destroy(collision.gameObject);
            lives--;
            Color cur = GetComponent<SpriteRenderer>().color;
            this.GetComponent<SpriteRenderer>().color = new Color(cur.r, cur.g, cur.b, cur.a-minusAlpha);
            if (lives <= 0)
                Destroy(gameObject);
        }
    }

}
