using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class playerManager : MonoBehaviour
{
    private bool isMeele;
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
        Attack();
    }

    void Move()
    {
    	horizontalAxis = Input.GetAxis("Horizontal");
    	verticalAxis = Input.GetAxis("Vertical");

    	rb.velocity = new Vector2(horizontalAxis * movementSpeed, verticalAxis * movementSpeed);
	}

    void Attack()
    {
        if(Input.GetButtonDown("Fire1") && isMeele)
        {
            //Meele attacks
        }
        else if(Input.GetButtonDown("Fire1") && !isMeele)
        {
            //Ranged attacks
        }
    }
}