using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class playerManager : MonoBehaviour
{
	private float horizontalAxis;
	private float verticalAxis;
	[HideInInspector]public bool isMoving;
	[Header("Movement Settings")]
	[SerializeField]private float movementSpeed;
	[SerializeField]private Rigidbody2D rb;


    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
    	horizontalAxis = Input.GetAxis("Horizontal");
    	verticalAxis = Input.GetAxis("Vertical");

    	rb.velocity = new Vector2(horizontalAxis * movementSpeed, verticalAxis * movementSpeed);
	}
}