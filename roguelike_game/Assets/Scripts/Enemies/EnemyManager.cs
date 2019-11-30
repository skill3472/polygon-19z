using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int enemyHealth;
    public int enemyDamageOutput;
    [SerializeField]private float damageFlashDuration;

    [SerializeField]private Sprite enemyNormalSprite;
    [SerializeField]private Sprite enemyFlashingSprite;

    [SerializeField]private float damageFlashTimer;

    public void TakeDamage(int weaponDamage)
    {
        damageFlashTimer = 0;
        enemyHealth -= weaponDamage;
        gameObject.GetComponent<SpriteRenderer>().sprite = enemyFlashingSprite;

        if (enemyHealth <= 0)
            EnemyDeath();
    }

    void Update()
    {
        damageFlashTimer += Time.deltaTime;
        if (damageFlashTimer >= damageFlashDuration) {
            damageFlashTimer = 0;
            gameObject.GetComponent<SpriteRenderer>().sprite = enemyNormalSprite;
        }
    }

    void EnemyDeath()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

}
