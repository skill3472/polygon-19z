using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            gameObject.SetActive(false);
            Destroy(gameObject);
            PickupEffect();
        }
    }
    public abstract void PickupEffect(); 


}
