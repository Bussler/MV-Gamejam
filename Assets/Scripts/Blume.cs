using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blume : MonoBehaviour
{
    // Start is called before the first frame update

    public int type;

  

    public int nectarToGive;
    

   
    public bool hasPollen;

    public bool isDead= false;

    public float timeToDie;

    public GameObject particle;

    void Start()
    {
        hasPollen = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToDie -= Time.deltaTime;
        if (timeToDie <= 0 &&hasPollen)
        {
            isDead = true;
            this.GetComponent<Animator>().SetBool("dead", true);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Test for player and do damage
        if (other.gameObject.tag == "Player" )
        {
            //GameObject.FindObjectOfType<StatManager>;
            if (hasPollen&&!isDead)
            {
                hasPollen = false;
                //hier die anzeige anschalten
                //GameObject.FindObjectOfType<PlayerMovement>().transform.GetChild(1).GetChild(type).gameObject.SetActive(true);

                StatManager.StatManagerInstance.AddPollType(type, nectarToGive);
                Instantiate(particle, this.transform.position, Quaternion.identity);
                
            }
        }
    }

    public void OnDisable()
    {
        isDead = false;
    }
}
