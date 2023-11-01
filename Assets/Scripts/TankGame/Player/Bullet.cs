using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : CustomUpdater
{
    public float speed;
    public int damage;
    public float lifetime;
    private float age;
    private ObjectPool poolReference;

    private void Start()
    {
        UpdateManagerGameplay.Instance.Add(this);
        GameObject pojectilePool = GameObject.Find("ProyectilePool");
        poolReference = pojectilePool.GetComponent<ObjectPool>();
    }

    public override void Tick()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(damage);
            poolReference.ReturnToPool(gameObject);
        }

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
    }
}
