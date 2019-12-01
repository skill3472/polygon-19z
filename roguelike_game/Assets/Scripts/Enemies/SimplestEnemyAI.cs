using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SimplestEnemyAI : MonoBehaviour
{

	[Header("AI Settings")]
    private Transform targetPlayer;
	[SerializeField][Tooltip("How fast the AI will rotate?")]
    private float rotationSpeed;
	[SerializeField][Tooltip("How fast will the AI walk?")]
    private float movementSpeed;
    [SerializeField][Range(0f,10f)][Tooltip("How far from the player will the AI stop walking and start shooting?")]
    private float safePlayerDistance;
    [SerializeField][Range(0f, 10f)][Tooltip("How far from the player will the AI start walking to player")]
    private float detectionPlayerDistance;
    [SerializeField][Tooltip("The AI's Rigidbody2D component")]
    private Rigidbody2D rb;
    
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null) {
            targetPlayer = player.transform;
        }
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
 		float step = movementSpeed * Time.deltaTime;

        if(Vector3.Distance(transform.position, targetPlayer.position) > safePlayerDistance && detectionPlayerDistance > Vector3.Distance(transform.position, targetPlayer.position))
        transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, step);
        else if(Vector3.Distance(transform.position, targetPlayer.position) < safePlayerDistance - 0.2f)
        transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, -step);
    }
}
