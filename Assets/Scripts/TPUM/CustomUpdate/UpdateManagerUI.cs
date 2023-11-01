using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManagerUI : MonoBehaviour
{
    [SerializeField] private float targetFps;
    private List<CustomUpdater> uiUpdater;
    private float timeToUpdate;
    private float now = 0;

    public static UpdateManagerUI Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            uiUpdater = new List<CustomUpdater>();
        }
    }

    private void Start()
    {
        timeToUpdate = 1 / targetFps;
    }

    private void Update()
    {
        now += Time.deltaTime;

        if (now >= timeToUpdate)
        {
            var count = uiUpdater.Count;

            for (int i = 0; i < count; i++)
            {
                uiUpdater[i].Tick();
            }
            now = 0;
        }

    }

    public void Add(CustomUpdater entity)
    {
        uiUpdater.Add(entity);
    }

    public void Remove(CustomUpdater entity)
    {
        uiUpdater.Remove(entity);
    }
}
