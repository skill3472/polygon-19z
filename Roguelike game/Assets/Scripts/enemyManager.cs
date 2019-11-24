using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public int enemyHealth;
    public int enemyDamageOutput;

    public void TakeDamage(int weaponDamage)
    {
        enemyHealth -= weaponDamage;

        if (enemyHealth <= 0)
            EnemyDeath();
    }

    void EnemyDeath()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

}
