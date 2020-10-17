using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   public enum Side{
        west,south,east,north
    }

   public Side side;
    private RoomTransition rt;
    // Start is called before the first frame update
    void Start()
    {
        rt = GameObject.FindObjectOfType<RoomTransition>();
    }

   


    public void OnTriggerEnter2D(Collider2D other)
    {
        switch (side)
        {

            case Side.west:
                rt.GoToNextRoomWest();

                break;
            case Side.east:
                rt.GoToNextRoomEast();

                break;
            case Side.south:
                rt.GoToNextRoomSouth();

                break;
            case Side.north:
                rt.GoToNextRoomNorth();

                break;


        }
    }

}
