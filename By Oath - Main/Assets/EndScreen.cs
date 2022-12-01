using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        SceneManager.LoadScene(4);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
