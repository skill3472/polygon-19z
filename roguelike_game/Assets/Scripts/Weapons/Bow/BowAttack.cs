﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAttack : Attack
{
    [SerializeField] GameObject projectile;

    public override void First()
    {
        Transform weaponTransform = GameObject.Find("Player").GetComponent<PlayerManager>().weaponSlot.gameObject.transform;
        GameObject arrow = Instantiate(projectile, weaponTransform.position, weaponTransform.rotation);
        Rigidbody2D arb = arrow.GetComponent<Rigidbody2D>();
        arb.AddForce(transform.right * 200, ForceMode2D.Force);
        Destroy(arrow, 3);
    }

    public override void Second()
    {
        Transform weaponTransform = GameObject.Find("Player").GetComponent<PlayerManager>().weaponSlot.gameObject.transform;
        GameObject arrow = Instantiate(projectile, weaponTransform.position, weaponTransform.rotation);
        arrow.transform.localScale += new Vector3(1f, 1f);
        Rigidbody2D arb = arrow.GetComponent<Rigidbody2D>();
        arb.AddForce(transform.right * 50, ForceMode2D.Force);
        Destroy(arrow, 6);
    }
}