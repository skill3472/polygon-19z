using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemyManager : BaseEnemyAi
{
    float time;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");

        if (player != null)
        {
            targetPlayer = player.transform;
        }
        time = Random.Range(0, 2f);
    }

    protected override void Behavior()
    {
        time = time + Time.deltaTime;
        if (time > 1.25f) {
            time = 0f;
            Vector2 dist = (transform.position - targetPlayer.position);
            dist.Normalize();
            dist = dist * movementSpeed * 150;

            if (detectionPlayerDistance > Vector3.Distance(transform.position, targetPlayer.position))
            {
                if (Vector3.Distance(transform.position, targetPlayer.position) > safePlayerDistance)
                {
                    rb.AddForce(-dist);
                }

                else if (Vector3.Distance(transform.position, targetPlayer.position) < safePlayerDistance)
                {
                    rb.AddForce(dist);
                }
            }
            else
            {
                {
                    rb.AddForce(Random.insideUnitCircle * movementSpeed * 150);
                }
            }
        }
    }
}
