using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WeaponCollisionManager : MonoBehaviour
{

	private PlayerManager playerManager;
	[SerializeField]private SwordAttack attackScript;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player").TryGetComponent<PlayerManager>(out playerManager);
    }

    // Update is called once per frame
    void Update()
    {
		attackScript.timeLeftToAttack += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(attackScript.timeLeftToAttack >= attackScript.attackRate)
		{
			timeLeftToAttack = 0;
        	Attack attackScript = this.GetComponent<Attack>();
        	playerManager.EnemyHit(col.gameObject, attackScript.damage);
		}
        if (this.CompareTag("Projectile") && !col.gameObject.CompareTag("Projectile"))
        {
        	gameObject.SetActive(false);
        	Destroy(gameObject);
        }
    }
}
