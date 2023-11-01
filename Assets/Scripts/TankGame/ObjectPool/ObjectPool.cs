using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public int amountToPool;
    [SerializeField] private GameObject objectPrefab;
    private Queue<GameObject> pooledObjects = new Queue<GameObject>();


    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            pooledObjects.Enqueue(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        GameObject poolObject;

        if(pooledObjects.Count > 0)
        {
            poolObject = pooledObjects.Dequeue();
            poolObject.SetActive(true);
            return poolObject;
        }
        else
        {
            poolObject = Instantiate(objectPrefab);
            pooledObjects.Enqueue(poolObject);
            return poolObject;
        }
    }

    public void ReturnToPool(GameObject poolObject)
    {
        poolObject.SetActive(false);
        pooledObjects.Enqueue(poolObject);
    }
   
}
