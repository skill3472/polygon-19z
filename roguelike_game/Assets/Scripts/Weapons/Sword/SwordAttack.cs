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
        StartCoroutine("FirstAttack");
    }

    public override void Second()
    {
        Rigidbody2D rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * dashForce, ForceMode2D.Impulse);
        StartCoroutine("FirstAttack");
        Debug.Log("Dashing with force: " + dashForce.ToString());
    }

    IEnumerator FirstAttack()
    {
        gameObject.transform.localScale = attackScale;
        gameObject.transform.localPosition = attackPosition;
        yield return new WaitForSeconds(attackTime);
        gameObject.transform.localScale = idleScale;
        gameObject.transform.localPosition = idlePosition;
    }
}
