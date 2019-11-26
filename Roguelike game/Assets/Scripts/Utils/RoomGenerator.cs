using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject topWall;
    public GameObject rightWall;
    public GameObject bottomWall;
    public GameObject leftWall;
    public int[] possibleRooms = new int[8];
    public GameObject[] currentRooms = new GameObject[8];


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; possibleRooms.Length > i ; i++)
        {
            possibleRooms[i] = Random.Range(0, 2);
        }

        for (int i = 0; possibleRooms.Length > i; i++)
        {
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

            currentRooms[i] = new GameObject("room " + i);
            currentRooms[i].transform.parent = this.transform;
            if (i ==4)
            {
                currentRooms[i].transform.position = new Vector3(currentRooms[i].transform.position.x, currentRooms[i].transform.position.y, 0);
            }

            if (i == 0 || i == 1 || i == 2)
            {
                currentRooms[i].transform.position = new Vector3(currentRooms[i].transform.position.x, currentRooms[i].transform.position.y + 9.4f, 0);
            }

            if (i == 0 || i == 3 || i == 6)
            {
                currentRooms[i].transform.position = new Vector3(currentRooms[i].transform.position.x - 17.1f, currentRooms[i].transform.position.y, 0);
            }

            if (i == 6 || i == 7 || i == 8)
            {
                currentRooms[i].transform.position = new Vector3(currentRooms[i].transform.position.x, currentRooms[i].transform.position.y - 9.4f, 0);
            }

            if (i == 2 || i == 5 || i == 8)
            {
                currentRooms[i].transform.position = new Vector3(currentRooms[i].transform.position.x + 17.1f, currentRooms[i].transform.position.y, 0);
            }
        }

        GameObject topWallInstance = Instantiate(topWall, currentRooms[4].transform);
        topWallInstance.transform.GetChild(2).GetComponent<PortalManager>().room1 = currentRooms[4];
        if (currentRooms[1] != null)
        {
            topWallInstance.transform.GetChild(2).GetComponent<PortalManager>().room2 = currentRooms[1];
        }

        GameObject rightWallInstance = Instantiate(rightWall, currentRooms[4].transform);
        rightWallInstance.transform.GetChild(1).GetComponent<PortalManager>().room1 = currentRooms[4];
        if (currentRooms[5] != null)
        {
            rightWallInstance.transform.GetChild(1).GetComponent<PortalManager>().room2 = currentRooms[5];
        }

        GameObject bottomWallInstance = Instantiate(bottomWall, currentRooms[4].transform);
        bottomWallInstance.transform.GetChild(2).GetComponent<PortalManager>().room1 = currentRooms[4];
        if (currentRooms[7] != null)
        {
            bottomWallInstance.transform.GetChild(2).GetComponent<PortalManager>().room2 = currentRooms[7];
        }

        GameObject leftWallInstance = Instantiate(leftWall, currentRooms[4].transform);
        leftWallInstance.transform.GetChild(1).GetComponent<PortalManager>().room1 = currentRooms[4];
        if (currentRooms[3] != null)
        {
            leftWallInstance.transform.GetChild(1).GetComponent<PortalManager>().room2 = currentRooms[3];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
