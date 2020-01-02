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

    void OnTriggerEnter2D(Collider2D col)
    {
		Attack attackScript = this.GetComponent<Attack>();
        if (Time.time > attackScript.lastAttackTime + attackScript.attackRate)
		{
			attackScript.lastAttackTime = Time.time;
        	playerManager.EnemyHit(col.gameObject, attackScript.damage);
		}
        if (this.CompareTag("Projectile") && !col.gameObject.CompareTag("Projectile"))
        {
        	gameObject.SetActive(false);
        	Destroy(gameObject);
        }
    }
}
