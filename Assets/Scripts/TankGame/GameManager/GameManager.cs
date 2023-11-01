using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject UI;
    [SerializeField] GameObject player;
    bool isGamePaused = false;
    public bool IsGamePaused => isGamePaused;

    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("UIController");
        player = GameObject.FindGameObjectWithTag("Player");
        UnPauseGame();
    } 
    public void PauseGame()
    {
        Time.timeScale = 0f;
        isGamePaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void UnPauseGame()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void PlayerDies()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(2);
    }
}
