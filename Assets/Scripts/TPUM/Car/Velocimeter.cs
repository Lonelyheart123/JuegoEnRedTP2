using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Velocimeter : CustomUpdater
{
   // private int count = 0;
    public CarController CarController;
   
    [SerializeField] TextMeshProUGUI velocityText;
    void Start()
    {       
        UpdateManagerUI.Instance.Add(this);      
    }

    public override void Tick()
    {       
        if (velocityText != null)
        {
            velocityText.text = ((int)CarController.speed) + "Km/h";
        }

        //count++;
        // Debug.Log("La ui se actualizó:" + count + "veces");
        //Esto es para ver si de verdad se esta actualizando el debido tiempo
    }
}
