using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WeaponCollisionManager : MonoBehaviour
{

	private PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player").TryGetComponent<PlayerManager>(out playerManager);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
		Attack attackScript = gameObject.GetComponent<Attack>();

        if (target.CompareTag("Enemy") && !gameObject.CompareTag("EnemyProjectile"))
        {
            playerManager.EnemyHit(target.gameObject, attackScript.damage);
        }
        else if (target.CompareTag("Player") && !gameObject.CompareTag("Projectile"))
        {
            target.gameObject.GetComponent<PlayerManager>().ChangeHp(-attackScript.damage);
        }


            //Remove projectile after collison
            if ((gameObject.CompareTag("Projectile") && !target.gameObject.CompareTag("Projectile") && !target.gameObject.CompareTag("Player"))
            || (gameObject.CompareTag("EnemyProjectile") && !target.gameObject.CompareTag("EnemyProjectile") && !target.gameObject.CompareTag("Enemy")))
        {
        	gameObject.SetActive(false);
        	Destroy(gameObject);
        }
    }
}
