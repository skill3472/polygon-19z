using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : Attack
{
    [SerializeField] private float dashForce;

    public override void First()
    {
        throw new System.NotImplementedException();
    }

    public override void Second()
    {
        Rigidbody2D rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * dashForce, ForceMode2D.Impulse);
        Debug.Log("Dashing with force: " + dashForce.ToString());
    }
}
