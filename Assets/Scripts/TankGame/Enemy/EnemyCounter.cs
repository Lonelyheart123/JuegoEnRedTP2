using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public int totalEnemies;
    public GameObject popUp;  
    public static EnemyCounter Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public void EnemyDie()
    {
        totalEnemies--;

        if(totalEnemies == 0)
        {
            popUp.SetActive(true);
            Time.timeScale = 0f;
        }
    }

  
}
