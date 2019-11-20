using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class simplestEnemyAI : MonoBehaviour
{

	[Header("AI Settings")]
	[SerializeField]private Transform targetPlayer;
	[SerializeField]private float rotationSpeed;
	[SerializeField]private float movementSpeed;
	[SerializeField]private Rigidbody2D rb;
    
    void Start()
    {
        
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
    	Vector3 vectorToTarget = targetPlayer.position - transform.position;
 		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
 		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
 		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);

 		float step = movementSpeed * Time.deltaTime;

        if(Vector3.Distance(transform.position, targetPlayer.position) > 2f)
        transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, step);
        else if(Vector3.Distance(transform.position, targetPlayer.position) < 2f)
        transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, -step);
        else
        transform.position = transform.position;
    }
}
