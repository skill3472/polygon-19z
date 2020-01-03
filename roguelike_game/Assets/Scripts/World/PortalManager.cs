using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameObject room1;
    public GameObject room2;
    public Sprite activePortal;
    public Sprite closedPortal;
    private GameObject mainCamera;
    private GameObject player;

    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
    }


    public void ActivatePortal()
    {
        if (room1 == null || room2 == null)
        {
            this.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = closedPortal;
            this.GetComponent<Collider2D>().isTrigger = false;
        } else
        {
            this.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = activePortal;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if ((other.Equals(GameObject.Find("Player").GetComponent<Collider2D>()) && room1 != null && room2 != null))
        {
            
            if (mainCamera.transform.position.x.Equals(room1.transform.position.x) && mainCamera.transform.position.y.Equals(room1.transform.position.y))
            {
                PlayerGoToRoom(room2);
            } else
            {
                PlayerGoToRoom(room1);
            }
        }
    }

    private void PlayerGoToRoom(GameObject room)
    {
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, new Vector3(room.transform.position.x, room.transform.position.y, mainCamera.transform.position.z), 3f);
        player.transform.position = new Vector2(room.transform.position.x, room.transform.position.y);
    }
}
