using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAttack : Attack
{
    [SerializeField] GameObject projectile;
    bool isCooldown = false;

    public override void First()
    {
        if (!isCooldown)
        {
            Transform weaponTransform = GameObject.Find("Player").GetComponent<PlayerManager>().weaponSlot.gameObject.transform;
            GameObject arrow = Instantiate(projectile, weaponTransform.position, weaponTransform.rotation);
            Rigidbody2D arb = arrow.GetComponent<Rigidbody2D>();
            arb.AddForce(transform.right * 400, ForceMode2D.Force);

            Attack attackScript = arrow.GetComponent<Attack>();
            attackScript.damage = attackScript.damage + damage;

            Destroy(arrow, 1f);
            StartCoroutine("coolDownFirst");
        }
        
    }

    public override void Second()
    {
        if (!isCooldown)
        {
            Transform weaponTransform = GameObject.Find("Player").GetComponent<PlayerManager>().weaponSlot.gameObject.transform;
            for (int i = -1; i <= 1;i++)
            {
                GameObject arrow = Instantiate(projectile, weaponTransform.position, weaponTransform.rotation);
                Rigidbody2D arb = arrow.GetComponent<Rigidbody2D>();
                arb.AddForce(transform.right * 400, ForceMode2D.Force);
                arb.AddForce(transform.up * 50 * i, ForceMode2D.Force);

                Attack attackScript = arrow.GetComponent<Attack>();
                attackScript.damage = attackScript.damage + damage;

                Destroy(arrow, 1f);
            }
            StartCoroutine("coolDownSecond");
        }
    }

    IEnumerator coolDownFirst()
    {   
        while (true)
        {
            if (isCooldown)
            {
                isCooldown = false;
                yield break;
            }
            else
            {
                isCooldown = true;
                yield return new WaitForSeconds(attackRate);
            }
        }   
    }

    IEnumerator coolDownSecond()
    {
        while (true)
        {
            if (isCooldown)
            {
                isCooldown = false;
                yield break;
            }
            else
            {
                isCooldown = true;
                yield return new WaitForSeconds(attackRate*2);
            }
        }
    }
}
