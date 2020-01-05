using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindowManager : MonoBehaviour
{
    [SerializeField] private GameObject[] items;

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void AddItem(GameObject obj)
    {


        Transform scrollView = gameObject.transform.Find("Scroll View");
        foreach (GameObject item in items)
        {
            Instantiate(item, scrollView, false);
        }
    }
}
