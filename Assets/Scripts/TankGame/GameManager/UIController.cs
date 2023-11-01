using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    
   //  [SerializeField] private Character player;
   
    private void Update()
    {
 
    }
    public void QuitButton()
    {
        Debug.Log("Se cerro el juego");
        Application.Quit();
    }
 
    
}
