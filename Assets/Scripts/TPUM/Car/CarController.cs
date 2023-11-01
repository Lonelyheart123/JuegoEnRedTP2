using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : CustomUpdater
{
    [System.Serializable]
    public class InfoEjes 
    {
        public WheelCollider ruedaIzquierda;
        public WheelCollider ruedaDerecha;
        public bool motor;
        public bool direction;
    }
  
    //private int count = 0;
    public float maxAngulodeGiro;
    public float mySpeedMotorToque;
    public float speed;
    private Rigidbody car;
  
    public List<InfoEjes> infoEjes;

    private void Start()
    {
        UpdateManagerGameplay.Instance.Add(this);
        car = GetComponent<Rigidbody>();
    }
   
    public override void Tick()
    {
         speed = car.velocity.magnitude * mySpeedMotorToque;
         float motor = Mathf.RoundToInt(mySpeedMotorToque * Input.GetAxis("Vertical"));
         float direction = Mathf.RoundToInt(maxAngulodeGiro * Input.GetAxis("Horizontal"));

        foreach (InfoEjes ejesInfo in infoEjes) 
        {
            if (ejesInfo.direction)
            {
                ejesInfo.ruedaIzquierda.steerAngle = direction;
                ejesInfo.ruedaDerecha.steerAngle = direction;
            }
            if (ejesInfo.motor)
            {
                ejesInfo.ruedaIzquierda.motorTorque = motor;
                ejesInfo.ruedaDerecha.motorTorque = motor;
            }
            PosWheels(ejesInfo.ruedaIzquierda);
            PosWheels(ejesInfo.ruedaDerecha);
        }
        
       // count++;
       // Debug.Log("El gameplay se actualizó:" + count + "veces");
       //Esto es para ver si de verdad se esta actualizando el debido tiempo
       
    }

    void PosWheels(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }
        Transform visualWheels = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheels.position = position;
        visualWheels.rotation = rotation;
    }

}