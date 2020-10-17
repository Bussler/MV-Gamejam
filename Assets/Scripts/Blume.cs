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

    void Start()
    {
        hasPollen = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Test for player and do damage
        if (other.gameObject.tag == "Player" )
        {
            //GameObject.FindObjectOfType<StatManager>;
            if (hasPollen)
            {
                //hier die anzeige anschalten
                //GameObject.FindObjectOfType<PlayerMovement>().transform.GetChild(1).GetChild(type).gameObject.SetActive(true);

                StatManager.StatManagerInstance.AddPollType(type, nectarToGive);
                hasPollen = false;
            }
        }
    }

    public void OnDisable()
    {
        isDead = false;
    }
}
