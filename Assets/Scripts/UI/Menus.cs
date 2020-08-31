using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public void JogarPress()
    {
        SceneManager.LoadScene("GameplayScene", LoadSceneMode.Single);
    }

    public void Recordes()
    {
        SceneManager.LoadScene("RecordsScene", LoadSceneMode.Single);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void Credits()
    {
        SceneManager.LoadScene("Creditos", LoadSceneMode.Single);
    }

    public void Exit()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }
}
