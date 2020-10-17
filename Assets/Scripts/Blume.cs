using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blume : MonoBehaviour
{
    // Start is called before the first frame update

    public enum BlumenType
    {
        none,
        red,
        blue,
        yellow,
        lila

    }

    public BlumenType type;

    public int nectarToGiveFirst;
        public int nectarToGiveSecond;

    public bool bestäubt;
    public bool hasPollen;

    void Start()
    {
        
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
            StatManager.StatManagerInstance.IsDead();
        }
    }
}
