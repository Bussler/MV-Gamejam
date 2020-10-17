using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    Transform spawnPos;

    public GameObject weapon;
    public GameObject player;

    public float lastTimeFired = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnPos == null)
            spawnPos = transform.GetChild(0);

        player = transform.parent.gameObject;
    }

    private void FixedUpdate()
    {
        //Darf geschossen werden?
        shoot();
    }

    void shoot()
    {
        bool didFire = false;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            player.GetComponent<SpriteRenderer>().flipX = false;
            player.transform.rotation = Quaternion.Euler(0, 0, 90);
            didFire = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            player.GetComponent<SpriteRenderer>().flipX = false;
            player.transform.rotation = Quaternion.Euler(0, 0, -90);
            didFire = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
            player.GetComponent<SpriteRenderer>().flipX = false;
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
            didFire = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            player.GetComponent<SpriteRenderer>().flipX = true;
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
            didFire = true;
        }

        //abfrage an shooting speed
       if (didFire && Time.time - lastTimeFired > StatManager.StatManagerInstance.GetFireRate())
        {
            GameObject honey = Instantiate(weapon, spawnPos.position, Quaternion.identity); //projectile shoot
            honey.GetComponent<HoneyMovement>().mvtVec = transform.up; //set facing direction
            //TODO set lifetime of honey according to player shooting range
            
            lastTimeFired = Time.time;
        }

    }
}
