using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerManager : MonoBehaviour
{
    private bool isMeele = true;
    private float horizontalAxis;
    private float verticalAxis;
    public int playerHealth = 100;
    //[SerializeField]private Animator anim;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject[] weaponList;
    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed;
    [Header("Game Over")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject inventoryWindowPrefarb;

    [HideInInspector] public int coins;
    [HideInInspector] public GameObject weaponSlot;
    [HideInInspector] public bool isMoving;
    [HideInInspector] public GameObject activeWindow;

    void Update()
    {
        WindowChecker();
        if (activeWindow == null)
        {
            Move();
            Attack();
            LookTowardsMouse();
            WeaponSwitch();
        }
    }

    private void WindowChecker()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (activeWindow == null)
            {
                activeWindow = Instantiate(inventoryWindowPrefarb, GameObject.FindGameObjectWithTag("UI").transform);
            } else
            {
                Destroy(activeWindow);
            }

        }
    }

    void Start()
    {
        weaponSlot = Instantiate(weaponList[0], this.gameObject.transform);
        weaponSlot.name = "0";
        gameOverPanel.SetActive(false);
    }

    void WeaponSwitch()
    {
        if (Input.GetButtonDown("Fire3"))
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

        if (Input.GetButtonDown("Fire2"))
        {
            weaponSlot.GetComponent<Attack>().Second();
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            weaponSlot.GetComponent<Attack>().First();
        }
    }


    public void EnemyHit(GameObject enemy, int damage)
    {
        if (enemy.CompareTag("Enemy"))
        {
            Debug.Log("Enemy was hit!");
            enemy.GetComponent<EnemyManager>().TakeDamage(damage);
        }
    }

    public void PlayerDeath(/*Possibly add a cause of death thing later*/)
    {
        if(playerHealth <= 0)
        {
            Debug.Log("Player died.");
            gameOverPanel.SetActive(true);
            gameOverPanel.transform.GetChild(0).GetComponent<Text>().text = "Player died.";
        }
    }

    public void AddCoin(int v)
    {
        coins += v;
        GameObject.FindGameObjectWithTag("Coins").GetComponent<Text>().text = coins.ToString();
    }
}
