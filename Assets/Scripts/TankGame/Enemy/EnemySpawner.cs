using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : CustomUpdater
{
    public Transform[] spawnPoints;
    public float timer;
    private float timerSet;
    private ObjectPool poolReference;


    private void Start()
    {
        UpdateManagerGameplay.Instance.Add(this);
        GameObject enemyPool = GameObject.Find("EnemyPool");
        poolReference = enemyPool.GetComponent<ObjectPool>();
        timerSet = timer;
    }

    public override void Tick()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            var enemyObject = poolReference.GetPooledObject();
            var randomSpawn = Random.Range(0,5);
            enemyObject.transform.position = spawnPoints[randomSpawn].position;
            timer = timerSet;
        }
    }

}
