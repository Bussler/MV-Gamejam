using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomTransition : MonoBehaviour
{
    public int coordX;

    public int coordY;
   

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
        Debug.Log("GetFloor");
        rooms = gameObject.GetComponent<LayoutGenerator>().GetFloor();
        
       // Debug.Log(rooms[4,4]);
        spawned = new bool[rooms.Length, rooms.Length];

        
        for(int i =0; i < 100; i++)
        {
            for (int l = 0; l < 100; l++)
            {
               // Debug.Log(i + "," + l);
                if (rooms[i, l].roomType == Room.RoomType.Starting)
                {
                    coordX = i;
                    coordY = l;
                }
            }
        }
      

        
        // Debug.Log(rooms[coordX, coordY].ToString());
        EnterNewRoom(rooms[coordX, coordY]);
       
       
      
    }

    // Update is called once per frame
   

  

    public void EnterNewRoom(Room room)
    {
        Debug.Log(rooms[coordX, coordY].ToString());
        // Debug.Log("" + room.doorWayEast);
        // Debug.Log("" + room.doorWayWest);
        // Debug.Log("" + room.doorWayNorth);
        // Debug.Log("" + room.doorWaySouth);
        // Destroy(activeRoom.gameObject);// TODO vllt nur inactiv setzen und schauen ob schon gespawnt und dann activ setzten, damit sachen im raum bestehen bleiben können und gegner nicht neu gespawnt werden
        if (activeRoom != null)
        {
            activeRoom.gameObject.transform.Translate(-1000,0,0);
        }
        if (spawned[coordX, coordY])//wenn es schon gespawned wurde
        {
            activeRoom = GameObject.Find("" + coordX + "," + coordY);
            //activeRoom.SetActive(true);
            activeRoom.gameObject.transform.Translate(1000, 0, 0);
            
        }
        else
        {

            switch (room.roomType)
            {
                case Room.RoomType.Regular:
                    activeRoom = Instantiate(roomPrefaps[Random.Range(0, roomPrefaps.Length)], Vector3.zero, Quaternion.identity);
                    activeRoom.name = "" + coordX + "," + coordY;
                    spawned[coordX, coordY] = true;
                    break;
                case Room.RoomType.Starting:
                    activeRoom = Instantiate(roomPrefaps[Random.Range(0, roomPrefaps.Length)], Vector3.zero, Quaternion.identity);
                    activeRoom.name = "" + coordX + "," + coordY;
                    spawned[coordX, coordY] = true;

                    break;
                case Room.RoomType.Shop:
                    activeRoom = Instantiate(shopRoomPrefaps[Random.Range(0, shopRoomPrefaps.Length)], Vector3.zero, Quaternion.identity);
                    activeRoom.name = "" + coordX + "," + coordY;
                    spawned[coordX, coordY] = true;
                    break;
                case Room.RoomType.Boss:
                    activeRoom = Instantiate(bossRoomPrefaps[Random.Range(0, bossRoomPrefaps.Length)], Vector3.zero, Quaternion.identity);
                    activeRoom.name = "" + coordX + "," + coordY;
                    spawned[coordX, coordY] = true;
                    break;
                case Room.RoomType.Item:
                    activeRoom = Instantiate(itemRoomPrefaps[Random.Range(0, itemRoomPrefaps.Length)], Vector3.zero, Quaternion.identity);
                    activeRoom.name = "" + coordX + "," + coordY;
                    spawned[coordX, coordY] = true;
                    break;

            }

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
        coordY -= 1;
        EnterNewRoom(rooms[coordX, coordY]);
        player.transform.position = southEntrance.transform.position;
    }
    public void GoToNextRoomSouth()
    {
        coordY += 1;
        EnterNewRoom(rooms[coordX, coordY]);
        player.transform.position = northEntrance.transform.position;
    }
    public void GoToNextRoomWest()
    {
        coordX += 1;
        EnterNewRoom(rooms[coordX, coordY]);
        player.transform.position = eastEntrance.transform.position;
    }
    public void GoToNextRoomEast()
    {
        coordX -= 1;
        EnterNewRoom(rooms[coordX, coordY]);
        player.transform.position = westEntrance.transform.position;
    }




}
