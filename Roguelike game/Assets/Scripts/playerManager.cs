using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class playerManager : MonoBehaviour
{
    private bool isMeele = true;
	private float horizontalAxis;
	private float verticalAxis;
	[HideInInspector]public bool isMoving;
    //[SerializeField]private Animator anim;
    [SerializeField]private Camera cam;
    [SerializeField]private GameObject weaponSlot;
	[Header("Movement Settings")]
	[SerializeField]private float movementSpeed;
    [SerializeField]private float dashForce;
	[SerializeField]private Rigidbody2D rb;

    void Update()
    {
        Move();
        Attack();
        LookTowardsMouse();
    }

    void Move()
    {
    	horizontalAxis = Input.GetAxis("Horizontal");
    	verticalAxis = Input.GetAxis("Vertical");

    	rb.velocity = new Vector2(horizontalAxis * movementSpeed, verticalAxis * movementSpeed);
	}

    void LookTowardsMouse()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 perpendicular = Vector3.Cross(transform.position-mousePos,Vector3.forward);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, perpendicular);
    }

    void Attack()
    {
        if(isMeele)
        {
            if(Input.GetButtonDown("Fire3"))
            Dash(dashForce);
            else if(Input.GetButtonDown("Fire1"))
            BasicAttack();
        }
        else if(Input.GetButtonDown("Fire1") && !isMeele)
        {
            //Ranged attacks TODO
        }
    }

    void Dash(float force)
    {
        rb.AddForce(transform.right * force, ForceMode2D.Impulse);
        Debug.Log("Dashing with force: " + force.ToString());
    }

    void BasicAttack()
    {
        //Basic attacks TODO
    }

    public void EnemyHit(GameObject enemy)
    {
        if(enemy.CompareTag("Enemy"))
        {
            Debug.Log("Enemy was hit!");
            //THERE SHOULD BE A REFERENCE TO THE ENEMY DAMAGE FUNCTION, BUT IT DOESNT EXIST YET TODO
        }
    }
}
