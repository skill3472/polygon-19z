using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPickUp : PickUp

{
    [SerializeField] private int hp;

    public override void PickupEffect()
    {
        GameObject.Find("Player").GetComponent<PlayerManager>().ChangeHp(hp);
    }
}
