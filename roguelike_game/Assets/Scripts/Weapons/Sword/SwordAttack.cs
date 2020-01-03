using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : Attack
{
    [SerializeField] private float dashForce;
    [SerializeField] private float attackTime;
    private float timeToAttack;
    private Vector3 attackScale;
    private Vector3 idleScale;
    private Vector3 attackPosition;
    private Vector3 idlePosition;

    void Start()
    {
        attackScale = gameObject.transform.localScale;
        idleScale = new Vector3(attackScale.x, attackScale.y / 5);
        gameObject.transform.localScale = idleScale;

        attackPosition = gameObject.transform.localPosition;
        idlePosition = new Vector3(0.04f, attackPosition.y);
        gameObject.transform.localPosition = idlePosition;
}

    public override void First()
    {
        if (Time.time > lastAttackTime + attackRate)
        {
            StartCoroutine("FirstAttack");
        }
    }

    public override void Second()
    {
        if (Time.time > lastAttackTime + attackRate * 3)
        {
            Rigidbody2D rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * dashForce, ForceMode2D.Impulse);
            StartCoroutine("FirstAttack");
        }
    }

    IEnumerator FirstAttack()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        lastAttackTime = Time.time;
        gameObject.transform.localScale = attackScale;
        gameObject.transform.localPosition = attackPosition;
        yield return new WaitForSeconds(attackTime);
        gameObject.transform.localScale = idleScale;
        gameObject.transform.localPosition = idlePosition;
        gameObject.GetComponent<Collider2D>().isTrigger = false;
    }
}
