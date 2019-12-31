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
        if (time > 2f) {
            time = 0f;
            Vector2 dist = (transform.position - targetPlayer.position) * movementSpeed * 100;

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
                    rb.AddForce(Random.insideUnitCircle * movementSpeed * 100);
                }
            }
        }
    }
}
