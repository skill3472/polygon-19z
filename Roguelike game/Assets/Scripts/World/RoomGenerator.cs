using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject topWall;
    public GameObject rightWall;
    public GameObject bottomWall;
    public GameObject leftWall;
    public int[] possibleRooms = new int[9];
    public GameObject[] currentRooms = new GameObject[9];


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; possibleRooms.Length > i; i++)
        {
            possibleRooms[i] = Random.Range(0, 2);
        }

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

            currentRooms[i] = new GameObject("room " + i);
            currentRooms[i].transform.parent = this.transform;

            //position created room object in correct coords for camera focus
            if (i == 4)
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

        // Walls room 4

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

        // walls room 1
        if (currentRooms[1] != null)
        {
            topWallInstance = Instantiate(topWall, currentRooms[1].transform);
            topWallInstance.transform.GetChild(2).GetComponent<PortalManager>().room1 = currentRooms[1];

            rightWallInstance = Instantiate(rightWall, currentRooms[1].transform);
            rightWallInstance.transform.GetChild(1).GetComponent<PortalManager>().room1 = currentRooms[1];
            if (currentRooms[2] != null)
            {
                rightWallInstance.transform.GetChild(1).GetComponent<PortalManager>().room2 = currentRooms[2];
            }

            leftWallInstance = Instantiate(leftWall, currentRooms[1].transform);
            leftWallInstance.transform.GetChild(1).GetComponent<PortalManager>().room1 = currentRooms[1];
            if (currentRooms[0] != null)
            {
                leftWallInstance.transform.GetChild(1).GetComponent<PortalManager>().room2 = currentRooms[0];
            }
        }
        // walls room 3
        if (currentRooms[3] != null)
        {
            topWallInstance = Instantiate(topWall, currentRooms[3].transform);
            topWallInstance.transform.GetChild(2).GetComponent<PortalManager>().room1 = currentRooms[3];
            if (currentRooms[0] != null)
            {
                topWallInstance.transform.GetChild(2).GetComponent<PortalManager>().room2 = currentRooms[0];
            }

            bottomWallInstance = Instantiate(bottomWall, currentRooms[3].transform);
            bottomWallInstance.transform.GetChild(2).GetComponent<PortalManager>().room1 = currentRooms[3];
            if (currentRooms[6] != null)
            {
                bottomWallInstance.transform.GetChild(2).GetComponent<PortalManager>().room2 = currentRooms[6];
            }

            leftWallInstance = Instantiate(leftWall, currentRooms[3].transform);
            leftWallInstance.transform.GetChild(1).GetComponent<PortalManager>().room1 = currentRooms[3];
        }
        // walls room 5
        if (currentRooms[5] != null)
        {
            topWallInstance = Instantiate(topWall, currentRooms[5].transform);
            topWallInstance.transform.GetChild(2).GetComponent<PortalManager>().room1 = currentRooms[5];
            if (currentRooms[2] != null)
            {
                topWallInstance.transform.GetChild(2).GetComponent<PortalManager>().room2 = currentRooms[2];
            }

            rightWallInstance = Instantiate(rightWall, currentRooms[5].transform);
            rightWallInstance.transform.GetChild(1).GetComponent<PortalManager>().room1 = currentRooms[5];

            bottomWallInstance = Instantiate(bottomWall, currentRooms[5].transform);
            bottomWallInstance.transform.GetChild(2).GetComponent<PortalManager>().room1 = currentRooms[5];
            if (currentRooms[8] != null)
            {
                bottomWallInstance.transform.GetChild(2).GetComponent<PortalManager>().room2 = currentRooms[8];
            }
        }
        // walls room 7
        if (currentRooms[7] != null)
        {
            rightWallInstance = Instantiate(rightWall, currentRooms[7].transform);
            rightWallInstance.transform.GetChild(1).GetComponent<PortalManager>().room1 = currentRooms[7];
            if (currentRooms[6] != null)
            {
                rightWallInstance.transform.GetChild(1).GetComponent<PortalManager>().room2 = currentRooms[6];
            }

            bottomWallInstance = Instantiate(bottomWall, currentRooms[7].transform);
            bottomWallInstance.transform.GetChild(2).GetComponent<PortalManager>().room1 = currentRooms[7];

            leftWallInstance = Instantiate(leftWall, currentRooms[7].transform);
            leftWallInstance.transform.GetChild(1).GetComponent<PortalManager>().room1 = currentRooms[7];
            if (currentRooms[8] != null)
            {
                leftWallInstance.transform.GetChild(1).GetComponent<PortalManager>().room2 = currentRooms[8];
            }
        }
        // walls room 0
        if (currentRooms[0] != null)
        {
            topWallInstance = Instantiate(topWall, currentRooms[0].transform);
            leftWallInstance = Instantiate(leftWall, currentRooms[0].transform);
            if (currentRooms[1] == null)
            {
                rightWallInstance = Instantiate(rightWall, currentRooms[0].transform);
            }
            if (currentRooms[3] == null)
            {
                bottomWallInstance = Instantiate(bottomWall, currentRooms[0].transform);
            }

            // walls room 2
            if (currentRooms[2] != null)
            {
                topWallInstance = Instantiate(topWall, currentRooms[2].transform);
                rightWallInstance = Instantiate(rightWall, currentRooms[2].transform);
                if (currentRooms[1] == null)
                {
                    leftWallInstance = Instantiate(leftWall, currentRooms[2].transform);
                }
                if (currentRooms[5] == null)
                {
                    bottomWallInstance = Instantiate(bottomWall, currentRooms[2].transform);
                }
            }
            // walls room 6
            if (currentRooms[6] != null)
            {
                leftWallInstance = Instantiate(leftWall, currentRooms[6].transform);
                bottomWallInstance = Instantiate(bottomWall, currentRooms[6].transform);
                if (currentRooms[0] == null)
                {
                    topWallInstance = Instantiate(topWall, currentRooms[6].transform);
                }
                if (currentRooms[7] == null)
                {
                    rightWallInstance = Instantiate(rightWall, currentRooms[6].transform);
                }
            }
            // walls room 8
            if (currentRooms[8] != null)
            {
                rightWallInstance = Instantiate(rightWall, currentRooms[8].transform);
                bottomWallInstance = Instantiate(bottomWall, currentRooms[8].transform);
                if (currentRooms[5] == null)
                {
                    topWallInstance = Instantiate(topWall, currentRooms[8].transform);
                }
                if (currentRooms[7] == null)
                {
                    leftWallInstance = Instantiate(leftWall, currentRooms[8].transform);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
