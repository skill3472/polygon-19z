using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerManager : MonoBehaviour
{
    private bool isMeele = true;
    private float horizontalAxis;
    private float verticalAxis;
    [HideInInspector] public bool isMoving;
    //[SerializeField]private Animator anim;
    [SerializeField] private Camera cam;
    [HideInInspector] public GameObject weaponSlot;
    [SerializeField] private GameObject[] weaponList;
    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed;

    void Update()
    {
        Move();
        Attack();
        LookTowardsMouse();
        WeaponSwitch();
    }

    void Start()
    {
        weaponSlot = Instantiate(weaponList[0], this.gameObject.transform);
        weaponSlot.name = "0";
    }

    void WeaponSwitch()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            int weaponIndex;
            Int32.TryParse(weaponSlot.name, out weaponIndex);
            weaponIndex++;
            if (weaponIndex >= weaponList.Length || weaponIndex == -1)
            {
                weaponIndex = 0;
            }
            Destroy(weaponSlot);
            weaponSlot = Instantiate(weaponList[weaponIndex], this.gameObject.transform);
            weaponSlot.name = weaponIndex.ToString();
        }
    }

    void Move()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalAxis * movementSpeed, verticalAxis * movementSpeed);
    }

    void LookTowardsMouse()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 perpendicular = Vector3.Cross(transform.position - mousePos, Vector3.forward);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, perpendicular);
    }

    void Attack()
    {

        if (Input.GetButtonDown("Fire3"))
        {
            weaponSlot.GetComponent<Attack>().Second();
        }
            else if (Input.GetButtonDown("Fire1"))
        {
            weaponSlot.GetComponent<Attack>().First();
        }
    }


    public void EnemyHit(GameObject enemy)
    {
        if (enemy.CompareTag("Enemy"))
        {
            Debug.Log("Enemy was hit!");
            //THERE SHOULD BE A REFERENCE TO THE ENEMY DAMAGE FUNCTION, BUT IT DOESNT EXIST YET TODO
        }
    }
}
