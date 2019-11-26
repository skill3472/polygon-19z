using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameObject room1;
    public GameObject room2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.Equals(GameObject.Find("Player").GetComponent<Collider2D>()))
        {
            Debug.Log("Player Enter Portal");
            // TODO zmienic na odpowiedni pokoj zamiast na this (Portal) bez mnoznika
            GameObject camera = GameObject.Find("Main Camera");
            camera.transform.position = Vector3.Lerp(camera.transform.position, new Vector3(this.transform.position.x*2, this.transform.position.y*2, camera.transform.position.z), 3f);
        }
        
    }
}
