using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : Attack
{
    [SerializeField] private float dashForce;
    [SerializeField] private Collider2D swordCollider;
    [SerializeField] private float attackTime;
    private float timeToAttack;

    public override void First()
    {
        StartCoroutine("FirstAttack");
    }

    public override void Second()
    {
        Rigidbody2D rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * dashForce, ForceMode2D.Impulse);
        Debug.Log("Dashing with force: " + dashForce.ToString());
    }

    IEnumerator FirstAttack()
    {
        swordCollider.offset = new Vector2(0.0f, 1.0f);
        yield return new WaitForSeconds(attackTime);
        swordCollider.offset = new Vector2(0.0f, 0.0f);
    }
}
