using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutGenerator : MonoBehaviour
{

    public Room[,] floor;

    public int roomCount = 20;

    private int indexX = 49;

    private int indexY = 49;

    private Queue<Room> roomsToBeAdded = new Queue<Room>();

    private Queue<Room> addedRooms = new Queue<Room>();

    private List<GameObject> cubes = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        floor = new Room[100, 100];
        for (int i = 0; i < 100; ++i)
        {   
            for (int j = 0; j < 100; ++j)
            {
                floor[i, j] = new Room { };
                floor[i, j].roomType = Room.RoomType.Empty;
                floor[i, j].coordX = i;
                floor[i, j].coordY = j;
            }
        }

        generateFloor(roomCount);
        //printFloor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //for debugging
    void printFloor()
    {
        for (int i = 0; i < 100; ++i)
        {
            for (int j = 0; j < 100; ++j)
            {
                if (floor[i, j].roomType != Room.RoomType.Empty)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(1.1f*i, 1.1f * j, 0);
                    if(floor[i, j].roomType == Room.RoomType.Starting)
                    {
                        cube.gameObject.GetComponent<Renderer>().material.color = Color.red;
                    }
                    cubes.Add(cube);
                    if(floor[i,j].doorWayNorth)
                    {
                        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        cube.transform.position = new Vector3(1.1f * i, 1.1f * (j - 0.5f), -0.1f);
                        cube.transform.localScale = new Vector3(0.25f, 0.25f,1);
                        cube.gameObject.GetComponent<Renderer>().material.color = Color.blue;
                        cubes.Add(cube);
                    }
                    if (floor[i, j].doorWaySouth)
                    {
                        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        cube.transform.position = new Vector3(1.1f * i, 1.1f * (j + 0.5f), -0.1f);
                        cube.transform.localScale = new Vector3(0.25f, 0.25f, 1);
                        cube.gameObject.GetComponent<Renderer>().material.color = Color.blue;
                        cubes.Add(cube);
                    }
                    if (floor[i, j].doorWayEast)
                    {
                        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        cube.transform.position = new Vector3(1.1f * (i + 0.5f), 1.1f * j, -0.1f);
                        cube.transform.localScale = new Vector3(0.25f, 0.25f, 1);
                        cube.gameObject.GetComponent<Renderer>().material.color = Color.blue;
                        cubes.Add(cube);
                    }
                    if (floor[i, j].doorWayWest)
                    {
                        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        cube.transform.position = new Vector3(1.1f * (i - 0.5f), 1.1f * j, -0.1f);
                        cube.transform.localScale = new Vector3(0.25f, 0.25f, 1);
                        cube.gameObject.GetComponent<Renderer>().material.color = Color.blue;
                        cubes.Add(cube);
                    }

                }

                //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

                //cube.transform.position = new Vector3(2 * i, 2 * j, 0);
                //cubes.Add(cube);
            }
        }
    }

    void generateFloor(int numberOfRooms)
    {
        
        Room startingRoom = new Room { };
        startingRoom.roomType = Room.RoomType.Starting;
        startingRoom.coordX = 49;
        startingRoom.coordY = 49;

        floor[indexX, indexY] = startingRoom;

        roomsToBeAdded.Enqueue(startingRoom);

        Room currentRoom = startingRoom;

        //Loop over and decide neighboring rooms
        while(numberOfRooms > 0)
        {
            if(roomsToBeAdded.Count == 0)
            {
                roomsToBeAdded = addedRooms;
                currentRoom = roomsToBeAdded.Peek();
            }


            //North = 0, East = 1, South = 2, West = 3
            List<int> directionsList = new List<int>() { 0, 1, 2, 3 };

            while(directionsList.Count != 0)
            {
                int upperRandomRange = 9;

                checkDirection(ref currentRoom, ref directionsList, ref upperRandomRange, ref numberOfRooms);
            }
            roomsToBeAdded.Dequeue();
            addedRooms.Enqueue(currentRoom);
            if(roomsToBeAdded.Count != 0)
                currentRoom = roomsToBeAdded.Peek();
        }
        
       
        
    }

    void setDoor(int direction, ref Room room, ref Room nextRoom)
    {
        switch (direction)
        {
            case 0:
                room.doorWayNorth = true;
                nextRoom.doorWaySouth = true;
                break;
            case 1:
                room.doorWayEast = true;
                nextRoom.doorWayWest = true;
                break;
            case 2:
                room.doorWaySouth = true;
                nextRoom.doorWayNorth = true;
                break;
            default:
                room.doorWayWest = true;
                nextRoom.doorWayEast = true;
                break;
        }
    }

    void checkDirection(ref Room room, ref List<int> directionsList, ref int upperRandomRange, ref int numberOfRooms)
    {
        int direction = directionsList[Random.Range(0, directionsList.Count)];

        int roll = Random.Range(0, upperRandomRange);


        bool roomAdded = false;

        if (roll < 5)
        {
            roomAdded = addRoom(ref room, direction);
        }
            

        if (roomAdded)
        {
            numberOfRooms--;
            upperRandomRange += 2;
        }
        

        directionsList.Remove(direction);
    }

    bool addRoom(ref Room room, int direction)
    {
        int indexX = room.coordX;
        int indexY = room.coordY;
        int nextX = 0;
        int nextY = 0;

        int axisX = 0;
        int axisY = 0;

        if (direction == 0)
        {
            axisY = -1;
            axisX = 0;
            nextX = 1;
        }
        else if (direction == 1)
        {
            axisX = 1;
            axisY = 0;
            nextY = 1;
        }
        else if (direction == 2)
        {
            axisY = 1;
            axisX = 0;
            nextX = 1;
        }
        else
        {
            axisY = 0;
            axisX = -1;
            nextY = 1;
        }

        


        if (indexX + axisX >= 0 && indexY + axisY >= 0 && indexX + axisX <= 99 && indexY + axisY <= 99 
            && floor[indexX + axisX, indexY + axisY].roomType == Room.RoomType.Empty)
        {
            if(floor[indexX + axisX * 2, indexY + axisY * 2].roomType == Room.RoomType.Empty && 
                floor[indexX + axisX + nextX, indexY + axisY + nextY].roomType == Room.RoomType.Empty &&
                floor[indexX + axisX - nextX, indexY + axisY + nextY].roomType == Room.RoomType.Empty &&
                floor[indexX + axisX + nextX, indexY + axisY - nextY].roomType == Room.RoomType.Empty &&
                floor[indexX + axisX - nextX, indexY + axisY - nextY].roomType == Room.RoomType.Empty)
            {
                Room nextRoom = floor[indexX + axisX, indexY + axisY];
                nextRoom.roomType = Room.RoomType.Regular;
                roomsToBeAdded.Enqueue(nextRoom);
                setDoor(direction, ref room, ref nextRoom);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
