using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void Start()
    {
        pauseMenu.SetActive(false);
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
    }
    public void Home()
    {
        SceneManager.LoadScene("MapScene");
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
