using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapManager : MonoBehaviour
{
    private bool isMinimapOn;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponentInParent<Canvas>().sortingOrder = -20;
        this.GetComponentInChildren<SpriteRenderer>().sortingOrder = -20;
        isMinimapOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (isMinimapOn)
            {
                this.GetComponentInParent<Canvas>().sortingOrder = -20;
                this.GetComponentInChildren<SpriteRenderer>().sortingOrder = -20;
                isMinimapOn = false;
            } else 
            {
                this.GetComponentInParent<Canvas>().sortingOrder = 25;
                this.GetComponentInChildren<SpriteRenderer>().sortingOrder = 24;
                isMinimapOn = true;
            }  
        }
    }
}
