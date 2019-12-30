using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SimplestEnemyAI : BaseEnemyAi
{

    protected override void Behavior()
    {
 		float step = movementSpeed * Time.deltaTime;

        if(Vector3.Distance(transform.position, targetPlayer.position) > safePlayerDistance && detectionPlayerDistance > Vector3.Distance(transform.position, targetPlayer.position))
        transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, step);
        else if(Vector3.Distance(transform.position, targetPlayer.position) < safePlayerDistance - 0.2f)
        transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, -step);
    }
}
