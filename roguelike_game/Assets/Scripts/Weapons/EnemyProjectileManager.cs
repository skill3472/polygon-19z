using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileManager : MonoBehaviour
{

    [HideInInspector]public int damage;

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.CompareTag("Player"))
        {
            target.gameObject.GetComponent<PlayerManager>().ChangeHp(-damage);
            Destroy(gameObject);
        }
    }
}
