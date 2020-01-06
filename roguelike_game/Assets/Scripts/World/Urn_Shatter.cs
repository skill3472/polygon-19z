using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urn_Shatter : MonoBehaviour
{
    public GameObject[] loot;
    public float[] lootChannce;
    public int[] lootCount;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D[] rigidbodies = this.GetComponentsInChildren<Rigidbody2D>();

        foreach (Rigidbody2D rb in rigidbodies)
        {
            rb.AddForce(Random.insideUnitCircle*25);
        }

        for (int i = 0; i < loot.Length; i++)
        {
            if (Random.Range(0f, 1f) < lootChannce[i])
            {
                int counter = 0;
                while(lootCount[i] > counter)
                {
                    GameObject obj = Instantiate(loot[i], transform.position, transform.rotation);
                    obj.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle * 45);
                    counter++;
                }
            }
        }

        Destroy(gameObject, 1f);
    }
}
