using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGridManager : MonoBehaviour
{
    public GameObject[] enemyList;
    public GameObject[] itemList;
    private int[,] grid = new int[13, 7];
    // Start is called before the first frame update
    void Start()
    {
        // 1 to 4 enemies
        int numberOfEnemies = Random.Range(1, 5);
        for (int i = 1; i <= numberOfEnemies; i++)
        {
            int x = Random.Range(0, 13);
            int y = Random.Range(0, 7);
            if (grid[x,y] == 0)
            {
                Instantiate(enemyList[0], this.transform.GetChild(x).transform.GetChild(y));
                grid[x, y] = 1;
            }

        }
        // 0 to 10 urns
        int numberOfUrns = Random.Range(0, 10);
        for (int i = 1; i <= numberOfUrns; i++)
        {
            int x = Random.Range(0, 13);
            int y = Random.Range(0, 7);
            if (grid[x, y] == 0)
            {
                Instantiate(itemList[0], this.transform.GetChild(x).transform.GetChild(y));
                grid[x, y] = 1;
            }

        }
    }
}
