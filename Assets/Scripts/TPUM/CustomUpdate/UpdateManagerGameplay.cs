using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManagerGameplay : MonoBehaviour
{
    [SerializeField] private float targetFps;
    private float timeToUpdate;
    private float now = 0;
    private List<CustomUpdater> gameplayUpdater;

    public static UpdateManagerGameplay Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            gameplayUpdater = new List<CustomUpdater>();
        }
    }

    private void Start()
    {
        timeToUpdate = 1 / targetFps; //precomputation
    }

    private void Update()
    {
        now += Time.deltaTime;

        if (now >= timeToUpdate)
        {
            var count = gameplayUpdater.Count;

            for (int i = 0; i < count; i++)
            {
                gameplayUpdater[i].Tick();
            }
            now = 0;
        }
    }

    public void Add(CustomUpdater entity)
    {
        gameplayUpdater.Add(entity);
    }

    public void Remove(CustomUpdater entity)
    {
        gameplayUpdater.Remove(entity);
    }
}
