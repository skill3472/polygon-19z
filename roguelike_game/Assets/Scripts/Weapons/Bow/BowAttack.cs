using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAttack : Attack
{
    [SerializeField] GameObject projectile;
    bool isCooldownFirst = false;

    public override void First()
    {
        if (!isCooldownFirst)
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
        Transform weaponTransform = GameObject.Find("Player").GetComponent<PlayerManager>().weaponSlot.gameObject.transform;
        GameObject arrow = Instantiate(projectile, weaponTransform.position, weaponTransform.rotation);
        arrow.transform.localScale += new Vector3(1f, 1f);
        Rigidbody2D arb = arrow.GetComponent<Rigidbody2D>();
        arb.AddForce(transform.right * 50, ForceMode2D.Force);
        Destroy(arrow, 6);
    }

    IEnumerator coolDownFirst()
    {   
        while (true)
        {
            if (isCooldownFirst)
            {
                isCooldownFirst = false;
                yield break;
            }
            else
            {
                isCooldownFirst = true;
                yield return new WaitForSeconds(attackRate);
            }
        }   
    }
}
