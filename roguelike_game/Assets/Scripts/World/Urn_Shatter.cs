using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urn_Shatter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D[] rigidbodies = this.GetComponentsInChildren<Rigidbody2D>();

        foreach (Rigidbody2D rb in rigidbodies)
        {
            rb.AddForce(Random.insideUnitCircle*25);
        }

        Destroy(gameObject, 1f);
    }
}
