using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtonManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    [SerializeField] GameManager gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gm.IsGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gm.UnPauseGame();
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        gm.PauseGame();
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitButton()
    {
        Debug.Log("Se cerro el juego");
        Application.Quit();
    }
}
