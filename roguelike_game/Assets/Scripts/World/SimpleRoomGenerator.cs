using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRoomGenerator : MonoBehaviour
{
    public GameObject room;
    public int[] possibleRooms = new int[9];
    public GameObject[] currentRooms = new GameObject[9];
    public int minRoomsNumber;


    // Start is called before the first frame update
    void Start()
    {
        if (minRoomsNumber == 0)
        {
            minRoomsNumber = 9;
        }
        int counter;
        do {
            counter = 0;
            for (int i = 0; possibleRooms.Length > i; i++)
            {
                possibleRooms[i] = Random.Range(0, 2);
                if (possibleRooms[i] == 1)
                {
                    counter++; 
                }
            }
        } while (minRoomsNumber > counter);

        for (int i = 0; possibleRooms.Length > i; i++)
        {
            // ommit loop for not possible room
            if ((i == 1 || i == 3 || i == 5 || i == 7) && possibleRooms[i] != 1)
            {
                continue;
            }
            else if (i == 0 && (possibleRooms[1] + possibleRooms[3] == 0))
            {
                continue;
            }
            else if (i == 2 && (possibleRooms[1] + possibleRooms[5] == 0))
            {
                continue;
            }
            else if (i == 6 && (possibleRooms[3] + possibleRooms[7] == 0))
            {
                continue;
            }
            else if (i == 8 && (possibleRooms[5] + possibleRooms[7] == 0))
            {
                continue;
            }

            currentRooms[i] = Instantiate(room, this.transform);
            currentRooms[i].name = "Room " + i;

            //position created room object in correct coords for camera focus
            if (i == 4)
            {
                currentRooms[i].transform.position = new Vector3(currentRooms[i].transform.position.x, currentRooms[i].transform.position.y, 0);
            }

            if (i == 0 || i == 1 || i == 2)
            {
                currentRooms[i].transform.position = new Vector3(currentRooms[i].transform.position.x, currentRooms[i].transform.position.y + 20f, 0);
            }

            if (i == 0 || i == 3 || i == 6)
            {
                currentRooms[i].transform.position = new Vector3(currentRooms[i].transform.position.x - 20f, currentRooms[i].transform.position.y, 0);
            }

            if (i == 6 || i == 7 || i == 8)
            {
                currentRooms[i].transform.position = new Vector3(currentRooms[i].transform.position.x, currentRooms[i].transform.position.y - 20f, 0);
            }

            if (i == 2 || i == 5 || i == 8)
            {
                currentRooms[i].transform.position = new Vector3(currentRooms[i].transform.position.x + 20f, currentRooms[i].transform.position.y, 0);
            }
        }

        // Portals room 4
        setupRoomPortals(4, 1, 5, 7, 3);
        // Portals room 0
        setupRoomPortals(0, -1, 1, 3, -1);
        // Portals room 1
        setupRoomPortals(1, -1, 2, 4, 0);
        // Portals room 2
        setupRoomPortals(2, -1, -1, 5, 1);
        // Portals room 3
        setupRoomPortals(3, 0, 4, 6, -1);
        // Portals room 5
        setupRoomPortals(5, 2, -1, 8, 4);
        // Portals room 6
        setupRoomPortals(6, 3, 7, -1, -1);
        // Portals room 7
        setupRoomPortals(7, 4, 8, -1, 6);
        // Portals room 8
        setupRoomPortals(8, 5, -1, -1, 7);

        // Activate portal GameObjects
        foreach (GameObject portal in GameObject.FindGameObjectsWithTag("Portal"))
        {
            portal.GetComponent<PortalManager>().ActivatePortal();
        }
    }

    private void setupRoomPortals(int room, int topRoom, int rightRoom, int bottomRoom, int leftRoom)
    {
        if (currentRooms[room] != null)
        {
            if (topRoom != -1 && currentRooms[topRoom] != null)
            {
                currentRooms[room].transform.GetChild(0).GetComponent<PortalManager>().room1 = currentRooms[topRoom];
                currentRooms[room].transform.GetChild(0).GetComponent<PortalManager>().room2 = currentRooms[topRoom];
            }
            if (rightRoom != -1 && currentRooms[rightRoom] != null)
            {
                currentRooms[room].transform.GetChild(1).GetComponent<PortalManager>().room1 = currentRooms[rightRoom];
                currentRooms[room].transform.GetChild(1).GetComponent<PortalManager>().room2 = currentRooms[rightRoom];
            }
            if (bottomRoom != -1 && currentRooms[bottomRoom] != null)
            {
                currentRooms[room].transform.GetChild(2).GetComponent<PortalManager>().room1 = currentRooms[bottomRoom];
                currentRooms[room].transform.GetChild(2).GetComponent<PortalManager>().room2 = currentRooms[bottomRoom];
            }
            if (leftRoom != -1 && currentRooms[leftRoom] != null)
            {
                currentRooms[room].transform.GetChild(3).GetComponent<PortalManager>().room1 = currentRooms[leftRoom];
                currentRooms[room].transform.GetChild(3).GetComponent<PortalManager>().room2 = currentRooms[leftRoom];
            }
        } 
    }
}
