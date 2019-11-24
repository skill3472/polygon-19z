using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject[] possibleRooms;
    public GameObject[] currentRooms;


    // Start is called before the first frame update
    void Start()
    {
        currentRooms[0] = null;
        currentRooms[1] = null;
        currentRooms[2] = null;
        currentRooms[3] = null;
        currentRooms[4] = null;
        currentRooms[5] = null;
        currentRooms[6] = null;
        currentRooms[7] = null;
        currentRooms[8] = null;

        currentRooms[4] = possibleRooms[Random.Range(0, possibleRooms.Length)];
        int room1 = Random.Range(0, 1);
        int room3 = Random.Range(0, 1);
        int room5 = Random.Range(0, 1);
        int room7 = Random.Range(0, 1);
        if(room1 == 1) currentRooms[1] = possibleRooms[Random.Range(0, possibleRooms.Length)];
        if(room3 == 1) currentRooms[3] = possibleRooms[Random.Range(0, possibleRooms.Length)];
        if(room5 == 1) currentRooms[5] = possibleRooms[Random.Range(0, possibleRooms.Length)];
        if(room7 == 1) currentRooms[7] = possibleRooms[Random.Range(0, possibleRooms.Length)];
        int room0 = Random.Range(0, 1);
        int room2 = Random.Range(0, 1);
        int room6 = Random.Range(0, 1);
        int room8 = Random.Range(0, 1);
        if(room0 == 1 && room3 == 1 || room0 == 1 && room1 == 1) currentRooms[0] = possibleRooms[Random.Range(0, possibleRooms.Length)];
        if(room2 == 1 && room1 == 1 || room2 == 1 && room5 == 1) currentRooms[2] = possibleRooms[Random.Range(0, possibleRooms.Length)];
        if(room6 == 1 && room3 == 1 || room6 == 1 && room7 == 1) currentRooms[6] = possibleRooms[Random.Range(0, possibleRooms.Length)];
        if(room8 == 1 && room5 == 1 || room8 == 1 && room7 == 1) currentRooms[8] = possibleRooms[Random.Range(0, possibleRooms.Length)];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
