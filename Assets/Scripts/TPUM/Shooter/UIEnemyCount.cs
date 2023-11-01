using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIEnemyCount : CustomUpdater
{
    
    public TextMeshProUGUI enemiesRemainingText;
    
    void Start()
    {
        UpdateManagerUI.Instance.Add(this);
    }

    public override void Tick()
    {
        enemiesRemainingText.text = EnemyCounter.Instance.totalEnemies.ToString();
    }
}
