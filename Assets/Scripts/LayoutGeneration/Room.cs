using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room 
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

    public RoomType roomType;

    //Roomcoordinates on floor

    public int coordX;

    public int coordY;

    public bool doorWayNorth = false;

    public bool doorWaySouth = false;

    public bool doorWayWest = false;

    public bool doorWayEast = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool allDoors()
    {
        return doorWayNorth && doorWayEast && doorWaySouth && doorWayWest;
    }

    public override string ToString()
    {
        return "East: " + doorWayEast + " West: " + doorWayWest + " South: " + doorWaySouth + " North: " + doorWayNorth;
    }
}
