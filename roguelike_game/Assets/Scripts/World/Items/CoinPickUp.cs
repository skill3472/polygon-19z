using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : PickUp
    
{
    public int value;

    public override void PickupEffect()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().AddCoin(value);
    }
}
