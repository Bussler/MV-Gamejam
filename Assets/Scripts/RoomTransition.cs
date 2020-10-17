using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    public int coordX;

    public int coordY;
    public struct Room
    {
        public enum RoomType
        {
            Starting,
            Boss,
            Shop,
            Item,
            Regular,
            Empty
        }


        public RoomType type;
       

       public  bool doorWayNorth ;

        public bool doorWaySouth ;

        public bool doorWayWest ;

        public bool doorWayEast ;
    }

    public Room[,] rooms;

    public bool[,] spawned;

    public GameObject DoorNorth;
    public GameObject DoorEast;
    public GameObject DoorWest;
    public GameObject DoorSouth;

    public GameObject activeRoom;

    public GameObject[] roomPrefaps;
    public GameObject[] shopRoomPrefaps;
    public GameObject[] itemRoomPrefaps;
    public GameObject[] bossRoomPrefaps;

    public Transform westEntrance;
    public Transform eastEntrance;
    public Transform southEntrance;
    public Transform northEntrance;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
        EnterNewRoom(rooms[4, 4]);
    }

    // Update is called once per frame
   

  

    public void EnterNewRoom(Room room)
    {
        // Destroy(activeRoom.gameObject);// TODO vllt nur inactiv setzen und schauen ob schon gespawnt und dann activ setzten, damit sachen im raum bestehen bleiben können und gegner nicht neu gespawnt werden

        activeRoom.gameObject.SetActive(false);
        if (spawned[coordX, coordY])//wenn es schon gespawned wurde
        {
            GameObject.Find("" + coordX + "," + coordY).SetActive(true);
            return;
        }

        switch (room.type)
        {
            case Room.RoomType.Regular:
             activeRoom=   Instantiate(roomPrefaps[Random.Range(0, roomPrefaps.Length)], Vector3.zero, Quaternion.identity);
                activeRoom.name = "" + coordX + "," + coordY;
                spawned[coordX, coordY] = true;
                break;
            case Room.RoomType.Shop:
                activeRoom= Instantiate(shopRoomPrefaps[Random.Range(0, shopRoomPrefaps.Length)], Vector3.zero, Quaternion.identity);
                activeRoom.name = "" + coordX + "," + coordY;
                spawned[coordX, coordY] = true;
                break;
            case Room.RoomType.Boss:
                activeRoom= Instantiate(bossRoomPrefaps[Random.Range(0, bossRoomPrefaps.Length)], Vector3.zero, Quaternion.identity);
                activeRoom.name = "" + coordX + "," + coordY;
                spawned[coordX, coordY] = true;
                break;
            case Room.RoomType.Item:
                activeRoom= Instantiate(itemRoomPrefaps[Random.Range(0, itemRoomPrefaps.Length)], Vector3.zero, Quaternion.identity);
                activeRoom.name = "" + coordX + "," + coordY;
                spawned[coordX, coordY] = true;
                break;

        }
       



        if (room.doorWayEast)
        {
            DoorEast.SetActive(true);
        }
        else
        {
            DoorEast.SetActive(false);
        }
        if (room.doorWayNorth)
        {
            DoorNorth.SetActive(true);
        }
        else
        {
            DoorNorth.SetActive(false);
        }
        if (room.doorWaySouth)
        {
            DoorSouth.SetActive(true);
        }
        else
        {
            DoorSouth.SetActive(false);
        }
        if (room.doorWayWest)
        {
            DoorWest.SetActive(true);
        }
        else
        {
            DoorWest.SetActive(false);
        }
    }


    public void GoToNextRoomNorth()
    {
        coordY += 1;
        EnterNewRoom(rooms[coordX, coordY]);
        player.transform.position = southEntrance.transform.position;
    }
    public void GoToNextRoomSouth()
    {
        coordY -= 1;
        EnterNewRoom(rooms[coordX, coordY]);
        player.transform.position = northEntrance.transform.position;
    }
    public void GoToNextRoomWest()
    {
        coordX -= 1;
        EnterNewRoom(rooms[coordX, coordY]);
        player.transform.position = eastEntrance.transform.position;
    }
    public void GoToNextRoomEast()
    {
        coordX += 1;
        EnterNewRoom(rooms[coordX, coordY]);
        player.transform.position = westEntrance.transform.position;
    }




}
