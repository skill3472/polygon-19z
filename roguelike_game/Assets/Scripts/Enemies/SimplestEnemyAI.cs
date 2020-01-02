using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SimplestEnemyAI : BaseEnemyAi
{
    [SerializeField]private GameObject projectilePrefab;
    [SerializeField]private float projectileSpeed;
    [SerializeField] private float projectileRate;
    private float lastProjectileAttackTime;

    protected override void Behavior()
    {
 		float step = movementSpeed * Time.deltaTime;
        GameObject projectile;

        if(Vector3.Distance(transform.position, targetPlayer.position) > safePlayerDistance && detectionPlayerDistance > Vector3.Distance(transform.position, targetPlayer.position))
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, step);
        else if(Vector3.Distance(transform.position, targetPlayer.position) < safePlayerDistance - 0.2f)
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, -step);
        else
        {
            if (Time.time > lastProjectileAttackTime + projectileRate)
            {
                lastProjectileAttackTime = Time.time;
                projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
                projectile.GetComponent<Rigidbody2D>().AddForce(Vector2.MoveTowards(gameObject.transform.position, targetPlayer.position, 10f).normalized * projectileSpeed);
                projectile.GetComponent<EnemyProjectileManager>().damage = gameObject.GetComponent<EnemyManager>().enemyDamageOutput;
            }
        }
    }
}
