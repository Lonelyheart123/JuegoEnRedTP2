using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : CustomUpdater
{
    public float speed;
    public int damage;
    private ObjectPool poolReference;

    private void Start()
    {
        UpdateManagerGameplay.Instance.Add(this);
        GameObject pojectilePool = GameObject.Find("BulletEnemyPool");
        poolReference = pojectilePool.GetComponent<ObjectPool>();
    }

    public override void Tick()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Wall wall = other.gameObject.GetComponent<Wall>();
            wall.TakeDamage(damage);
            poolReference.ReturnToPool(gameObject);
        }

        if (other.gameObject.CompareTag("Perimeter"))
        {
            poolReference.ReturnToPool(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.TakeDamage(damage);
            poolReference.ReturnToPool(gameObject);
        }
    }
}
