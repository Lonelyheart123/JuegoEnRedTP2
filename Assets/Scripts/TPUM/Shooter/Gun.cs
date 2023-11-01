using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gun : CustomUpdater
{
    private float count;
    public float life;
    public GameObject proyectil;
    public Transform bulletSpawner;
    public float bulletSpeed;
    public int cantProyectiles;
    public int cantidadTotalProyectiles;
    
    void Start()
    {
        UpdateManagerGameplay.Instance.Add(this);
    }

    public override void Tick()
    {
        Attack();
        Reload();

        count++;
        Debug.Log("El Gameplay se actualizó:" + count + "veces");
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (cantProyectiles > 0)
            {
                var bullet = Instantiate(proyectil, bulletSpawner.position, bulletSpawner.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawner.forward * bulletSpeed;
                Destroy(bullet, life);
                cantProyectiles -= 1;
            }
        }
    }

    public void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            cantProyectiles += cantidadTotalProyectiles;
            cantidadTotalProyectiles = 0;
        }
    }
}
