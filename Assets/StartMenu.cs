using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("grass", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
