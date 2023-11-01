using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void HomeButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
    public void TutorialButton()
    {
        SceneManager.LoadScene(4);
    }
    public void QuitButton()
    {
        Debug.Log("Se cerro el juego");
        Application.Quit();
    }    
}
