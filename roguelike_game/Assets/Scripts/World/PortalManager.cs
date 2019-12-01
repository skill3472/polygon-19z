using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameObject room1;
    public GameObject room2;
    public Sprite activePortal;
    public Sprite closedPortal;

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
            Debug.Log("Player Enter Portal");
            GameObject camera = GameObject.Find("Main Camera");
            if (camera.transform.position.x.Equals(room1.transform.position.x) && camera.transform.position.y.Equals(room1.transform.position.y))
            {
                camera.transform.position = Vector3.Lerp(camera.transform.position, new Vector3(room2.transform.position.x, room2.transform.position.y, camera.transform.position.z), 3f);
                GameObject.Find("Player").transform.position = new Vector2(room2.transform.position.x, room2.transform.position.y);
            } else
            {
                camera.transform.position = Vector3.Lerp(camera.transform.position, new Vector3(room1.transform.position.x, room1.transform.position.y, camera.transform.position.z), 3f);
                GameObject.Find("Player").transform.position = new Vector2(room1.transform.position.x, room1.transform.position.y);
            }
            


        }
        
    }
}
